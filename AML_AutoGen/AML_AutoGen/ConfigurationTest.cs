using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCatSysManagerLib;
using ScriptingTest;

namespace AML_AutoGen
{
    class ConfigurationTest
        : CodeGenerationBaseScript
    {
        protected override void OnExecute(IWorker worker)
        {
            worker.Progress = 0;

           // bool optScanHardware = this._context.Parameters.ContainsKey("ScanHardware");
            //bool optSimulate = this._context.Parameters.ContainsKey("SimulateHardware");

            //ITcSmTreeItem ncConfig = systemManager.LookupTreeItem("TINC"); // Getting NC Configuration

            ITcSmTreeItem plcConfig = systemManager.LookupTreeItem("TIPC"); // Getting PLC-Configuration
            
            //ITcSmTreeItem devices = systemManager.LookupTreeItem("TIID"); // Getting IO-Configuration

            //ITcSmTreeItem device = CreateHardware(worker, optScanHardware, optSimulate);

            CreatePlcProject(worker); // Method of CodeGenerationBaseScript to create a new PLC project.
            //CreateMotion(worker);
            //CreateMappings(worker);
        }
    }
}
