using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScriptingTest;
using CAEX_ClassModel;
using System.Xml;

namespace AML_AutoGen
{
    public partial class Form1 : Form
    {
        private CAEXDocument myDoc;
        private string fileName;        
        private int _fbNumber;

        XmlDocument doc = new XmlDocument();
        OrderCollection _orders = new OrderCollection();
        ConfigurationCollection _configurations = new ConfigurationCollection();

        /// <summary>
        /// Background script worker
        /// </summary>
        IWorker _worker = null;

        /// <summary>
        /// Configuration Generator
        /// </summary>
        ConfigurationFactory _factory = null;

        /// <summary>
        /// Currently runnig script
        /// </summary>
        Script _runningScript = null;

        public Form1()
        {          
            InitializeComponent();
        }

        /// <summary>
        /// Handling the event of the open CAEX button        
        /// </summary>
        private void _BopenCAEX_Click(object sender, EventArgs e)
        {
            if (_openFile.ShowDialog() == DialogResult.OK)
            {
                this._CTV.PathSeparator = "/";
                this.myDoc = null;
                this._CTV.Nodes.Clear();
                this.fileName = _openFile.FileName; // Gets or sets a string containing the file name selected in the file dialog box.
                _FileName.Text = fileName;
                myDoc = CAEXDocument.LoadFromFile(fileName);
                this.myShowTree(_CTV, myDoc);
                this._CTV.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(GenerateEnable);
                this.Open();
            }
        }

        /// <summary>
        /// It shows the CAEX-Datei in a tree structure        
        /// </summary>
        private void myShowTree(TreeView TV, CAEXDocument doc)
        {
            // Showing the InstanceHierarchy window  
            foreach (InstanceHierarchyType IH in doc.CAEXFile.InstanceHierarchy)
            {
                TreeNode node = TV.Nodes.Add(IH.Name.Value);
                node.Tag = IH;
                foreach (InternalElementType IE in IH.InternalElement)
                {
                    myShowIE(node, IE);                                        
                }
            }

            // showing roleClass window
            foreach (RoleClassLibType RL in doc.CAEXFile.RoleClassLib)
            {
                TreeNode node = TV.Nodes.Add(RL.Name.Value);
                node.Tag = RL;
                foreach (RoleFamilyType RC in RL.RoleClass)
                {
                    myShowRC(node, RC);
                }
            }

            // Showing system unit class window
            foreach (SystemUnitClassLibType SUCL in doc.CAEXFile.SystemUnitClassLib)
            {
                TreeNode node = TV.Nodes.Add(SUCL.Name.Value);
                node.Tag = SUCL;
                foreach (SystemUnitFamilyType SUC in SUCL.SystemUnitClass)
                {
                    myShowSUC(node, SUC);
                }
            }
        }

        private void myShowIE(TreeNode node, InternalElementType IE)
        {
            TreeNode childNode = node.Nodes.Add(IE.Name.Value);
            childNode.Tag = IE;            
            foreach (InternalElementType childIE in IE.InternalElement)
            {
                myShowIE(childNode, childIE);
            }
        }

        private void myShowRC(TreeNode node, RoleFamilyType RC)
        {
            TreeNode childNode = node.Nodes.Add(RC.Name.Value);
            childNode.Tag = RC;
            foreach (RoleFamilyType childRC in RC.RoleClass)
            {
                myShowRC(childNode, childRC);
            }
        }

        private void myShowSUC(TreeNode node, SystemUnitFamilyType SUC)
        {
            TreeNode childNode = node.Nodes.Add(SUC.Name.Value);
            childNode.Tag = SUC;            

            foreach (InternalElementType IE in SUC.InternalElement)
            {
                myShowIE(childNode, IE);                
            }

            foreach (SystemUnitFamilyType childSUC in SUC.SystemUnitClass)
            {
                myShowSUC(childNode, childSUC);
            }

        }
        
        /// <summary>
        /// Handling the event of the generate button.
        /// It generates a new TwinCat configuration
        /// </summary>
        private void _BgeneratePLC_Click(object sender, EventArgs e)
        {
            //this.Open();
            //Debug.Assert(this._factory == null);
            try
            {
                OrderInfo order = this._orders[this._fbNumber];  // selects just the first item in the order.xml. TODO: connection with the AML SUC. 
                Script script = ScriptLoader.GetScript(order.ConfigurationInfo.Script);  // get the script under AvailableConfiguration of the order item previously selected 
                
                if (script == null)
                    throw new ApplicationException(string.Format("Script '{0}' not found. Cannot start execution!", order.ConfigurationInfo.Script));

                _runningScript = script;   // setting the running script with the one previously selected                

                VsFactory fact = new VsFactory(); // VS factory to create the DTE Object and determine the VS version to integrate with TC

                if (_runningScript is ScriptEarlyBound)
                    this._factory = new EarlyBoundFactory(fact);
                else if (_runningScript is ScriptLateBound)
                    this._factory = new LateBoundFactory(fact);

                if (this._factory == null)
                {
                    throw new ApplicationException("Generator not found!");
                }

                OrderScriptContext context = new OrderScriptContext(this._factory, order); // we need to set the context of the script

                _worker = new ScriptBackgroundWorker(/*this._factory,*/ _runningScript, context); // worker for asynchronous script execution 

                // Showing TwinCat UI and keeping it open after the creation of the code
                _factory.IsIdeVisible = true;
                _factory.IsIdeUserControl = true;   
                _factory.SuppressUI = true;                

                // Script execution: In Workerthread.cs it does OnDoWork() which has the main functions: Initialization, Execution and Cleanup
                _worker.BeginScriptExecution();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        /// <summary>
        /// Opening an .xml file with the informations for the implementation of function blocks in TC        
        /// </summary>
        private void Open()
        {
            this.doc.Load(@".\Orders.xml");   // TODO: open any file.xml and not only Orders.

            XmlNodeList configurationNodes = doc.SelectNodes("Root/AvailableConfigurations/Configuration");

            foreach (XmlElement configurationNode in configurationNodes)
            {
                _configurations.Add(new ConfigurationInfo(configurationNode));  // adding configuration Info
            }

            XmlNodeList orderNodes = doc.SelectNodes("Root/MachineOrders/Order");

            foreach (XmlElement orderNode in orderNodes)
            {
                _orders.Add(new OrderInfo(orderNode));       // adding order information
            }
        }

        /// <summary>
        /// Handling the event of the selection of the tree nodes        
        /// </summary>
        private void GenerateEnable(object sender, EventArgs e)
        {
            //MessageBox.Show(this._CTV.SelectedNode.FullPath); 
            foreach (var o in this._orders)
            {
                if (this._CTV.SelectedNode.Text == o.ProjectName)
                {
                    this._fbNumber = o.Serial;
                    this._generatePLC.Enabled = true;
                    break;
                }
                else { this._generatePLC.Enabled = false; }
            }

        }
    }
}
