using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System.Runtime.InteropServices;
using System.Collections;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace ConsoleApplication1
{
    class MainLogic
    {
        public WorkItemLinkTypeEnd ForwardEnd { get; set; }
        StringBuilder sbr = new StringBuilder();

        public void mainMethodd()
        {
            #region guk1
            //    // [DllImport("Microsoft.WITDataStore32.dll", CharSet = CharSet.Unicode)]
            //    string bugnumber = Console.ReadLine();

            //    TfsTeamProjectCollection tpc= new TfsTeamProjectCollection(new Uri("http://alm-prod-app1:8080/tfs/boc_projects"));

            //    tpc.EnsureAuthenticated();
            //    WorkItemStore item = (WorkItemStore)tpc.GetService(typeof(WorkItemStore));

            //WorkItem number = item.GetWorkItem(Int32.Parse(bugnumber));

            //    //linkeite
            //   // WorkItemType wiType = item.Projects[0].WorkItemTypes[10];
            //  // WorkItemLinkTypeEnd type= (WorkItemLinkTypeEnd)item.Projects[0].WorkItemTypes[10];
            //    WorkItemLinkTypeEnd linkTyp=item.WorkItemLinkTypes.LinkTypeEnds[wiTyp]
            #endregion

            #region guk2
            
            using (var projectCollection = TfsTeamProjectCollectionFactory.
            GetTeamProjectCollection(new Uri("http://alm-prod-app1:8080/tfs/boc_projects")))
            {
                // get the work item store for the collection
                var workItemStore = projectCollection.GetService<WorkItemStore>();

                // get the link type for hierarchical relationships
                var linkType = workItemStore.WorkItemLinkTypes[CoreLinkTypeReferenceNames.Hierarchy];
                //start reading the file
                // int[] parentNumbers=readTextFile();

                string[] fileContent = readFileContent();
                // fetch the work items to be linked
                //var parentNumber = getParentNumber();

                //*************

                // this is one more time new code
                for (int i = 0; i < fileContent.Length; i++)
                {
                    if (fileContent[i].Split('#')[0] == "") break;
                    var parentWorkItem = workItemStore.GetWorkItem(Convert.ToInt32(fileContent[i].Split('#')[0]));
                    var childWorkItem = workItemStore.GetWorkItem(createChild(parentWorkItem,fileContent[i]));
                    parentWorkItem.Links.Add(new WorkItemLink(linkType.ForwardEnd, childWorkItem.Id));
                    parentWorkItem.Save();
                }
                //this is new code

                //for (int i = 0; i < parentNumbers.Length; i++)
                //{
                //    var parentWorkItem = workItemStore.GetWorkItem(parentNumbers[i]);
                //    var childWorkItem = workItemStore.GetWorkItem(createChild(parentWorkItem));
                //    parentWorkItem.Links.Add(new WorkItemLink(linkType.ForwardEnd, childWorkItem.Id));
                //    parentWorkItem.Save();
                //}
                //*************
              //  var parentWorkItem = workItemStore.GetWorkItem(1226648);  //parent
              
                //var childWorkItem = workItemStore.GetWorkItem(createChild(parentWorkItem)); // child no

                // add a new link to the parent relating the child and save it
               // parentWorkItem.Links.Add(new WorkItemLink(linkType.ForwardEnd, childWorkItem.Id));
                //parentWorkItem.Save();
                #endregion
            }
        }

        //demo method for real method
        public int createChild(WorkItem parentWorkItem)
        {
            WorkItemType wiType = parentWorkItem.Project.WorkItemTypes["Release Note"];
            WorkItem newWI = new WorkItem(wiType);
            newWI.Title = parentWorkItem.Title.ToString();   //titel same as parent bug
            newWI.State = "Draft";
            //newWI.Fields["Release Note Header"].Value = "guk creating this rnote";  // header needs to be intelligent
           // StringBuilder Rnote = getRnote();
            newWI.Fields["Release Note"].Value = sbr.ToString();
            newWI.Fields["Iteration Path"].Value = "SPFM\\PFM\\Sustaining";
           // newWI.Fields["Type"].Value = "Resolved Issue";
            newWI.Fields["Release Note Audience"].Value = "Both";
            newWI.Fields["Release Note Type"].Value = "Resolved Issue";
            newWI.Save();
            

            return newWI.Id;
        }

        //actual method
        public int createChild(WorkItem parentWorkItem,string Rlnote)
        {
            WorkItemType wiType = parentWorkItem.Project.WorkItemTypes["Release Note"];
            WorkItem newWI = new WorkItem(wiType);
            newWI.Title = parentWorkItem.Title.ToString();   //titel same as parent bug
            newWI.State = "New";
            //newWI.Fields["Release Note Header"].Value = "guk creating this rnote";  // header needs to be intelligent
            StringBuilder Rnote = getRnote(Rlnote);
            newWI.Fields["Release Note"].Value = sbr.ToString();
            newWI.Fields["Iteration Path"].Value = "SPFM\\PFM\\Sustaining";
            // newWI.Fields["Type"].Value = "Resolved Issue";
            newWI.Fields["Release Note Audience"].Value = "Both";
            newWI.Fields["Release Note Type"].Value = "Resolved Issue";
            newWI.Save();


            return newWI.Id;
        }
        //actual method
        public StringBuilder getRnote(string str)
        {
            sbr.Clear();
            for (int i = 1; i < 4; i++)
            {
                switch (i)
                {
                    case 1:sbr.Append("Problem Description :-");
                        break;
                    case 2:sbr.Append("Fix Description :-");
                        break;
                    case 3:sbr.Append("Testing Consideration :-");
                        break;
                    default:
                        break;
                }
                sbr.Append(Environment.NewLine);
                string tempString = str.Split('#')[i];
                sbr.Append(tempString);
                sbr.Append(Environment.NewLine);
                sbr.Append(Environment.NewLine);


            }
            sbr.Append("Clients: ALL CLIENTS");
            return sbr;
        }
        //demo method for actual method
        public StringBuilder getRnote()
        {
            //StringBuilder sbr = new StringBuilder();
            string[] lines;
            var list = new List<string>();
            var fileStream = new FileStream(@"c:\GUK.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }
            fileStream.Close();
            fileStream.Dispose();
            lines = list.ToArray();

            //for (int i = 0; i < 4; i++)
            //{
            //  string  tempString = lines[0].Split('#')[i];
            //    sbr.Append(tempString);
            //    sbr.Append(Environment.NewLine);
            //}
            //sbr.Append("Clients: ALL CLIENTS");




            //return sbr;
            return null;
        }
        public int[] readTextFile()
        {
            string[] lines;
            int[] linesnumber;
            var listnumbers = new List<int>();
            var list = new List<string>();
           
            var fileStream = new FileStream(@"c:\GUK.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }
            fileStream.Close();
            fileStream.Dispose();
            lines = list.ToArray();

            // read bug number only from first line
            for (int i = 0; i < lines.Length; i++)
            {
                string tempString = lines[i].Split('#')[0];
                listnumbers.Add(Convert.ToInt32(tempString));

            }
            linesnumber = listnumbers.ToArray();



            //read the release note in sbr object of string builder

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    string tempString = lines[i].Split('#')[j];
                    sbr.Append(tempString);
                    sbr.Append(Environment.NewLine);
                    sbr.Append("Clients: ALL CLIENTS");
                }

            }

            // read bug number

            //read fix and number
            //for (int i = 0; i < 4; i++)
            //{
            //    string tempString = lines[0].Split('#')[i];
            //    //linesnumber[]
            //    sbr.Append(tempString);
            //    sbr.Append(Environment.NewLine);
            //}
            //sbr.Append("Clients: ALL CLIENTS");


            //read the fix# and the description and pad all clients at end
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    string tempString = lines[i].Split('#')[j];
                    if (tempString == "") break;
                    if (j == 0)
                    {
                        listnumbers.Add(Convert.ToInt32(tempString));
                        break;
                    }

                    sbr.Append(tempString);
                    sbr.Append(Environment.NewLine);
                    sbr.Append("Clients: ALL CLIENTS");
                }
                
            }
            linesnumber = listnumbers.ToArray();
            return linesnumber;
        }
        


        //final reading method
        public string[] readFileContent()             // this should be final reading thing
        {
            string[] lines;
            var listOfLines = new List<string>();
           
                OpenFileDialog ObjOpen = new OpenFileDialog();
                ObjOpen.ShowDialog();
            // ObjOpen.OpenFile();
            var fileStream = ObjOpen.OpenFile();
            //var filename
            // var fileStream = new FileStream(@"c:\GUK.txt", FileMode.Open, FileAccess.Read);
            //var fileStream = new FileStream(ObjOpen.OpenFile().ToString(),FileMode.Open);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                   listOfLines.Add(line);
                }
            }
            fileStream.Close();
            fileStream.Dispose();
            lines = listOfLines.ToArray();
            return lines; 
        }
    }
}

