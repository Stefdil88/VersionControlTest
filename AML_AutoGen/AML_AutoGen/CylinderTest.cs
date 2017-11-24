using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCatSysManagerLib;
using ScriptingTest;

namespace AML_AutoGen
{
    class CylinderTest : CodeGenerationBaseScript
    {
        protected override void OnExecute(IWorker worker)
        {
            worker.Progress = 0;

            ITcSmTreeItem plcConfig = systemManager.LookupTreeItem("TIPC"); // Getting PLC-Configuration

            CreatePlcProject(worker); // Method of CodeGenerationBaseScript to create a new PLC project.            
        }
    }
}
