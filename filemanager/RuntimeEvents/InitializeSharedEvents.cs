using filemanager.Dialogs;

namespace filemanager
{
    public partial class Manager
    {
        private void InitializeSharedEvents(DisplayHandler displayHandler, DirectoryHandler directoryHandler, FileWatcher fileWatcher)
        {

            changeAttributesTool.Click += (sender, e) =>
            {
                if (!displayHandler.Focused) return;
                if (displayHandler.isSelected())
                {
                    DialogChangeAttribute dialog = new DialogChangeAttribute(
                        displayHandler.ListView.SelectedItems.Cast<ListViewItem>()
                            .Select(item => item.ETag().Path)
                            .ToList());
                    dialog.ShowDialog(); Refresh(displayHandler, directoryHandler);
                }
            };
            
            openInExplorerTool.Click += (sender, e) => 
            {
                if (!displayHandler.Focused) return;
                if (displayHandler.isSelected())
                {
                    if (displayHandler.ListView.SelectedItems[0].ETag().Type == "directory")
                    {
                        ProcessCall.RunProcess("explorer.exe", displayHandler.ListView.SelectedItems[0].ETag().Path);
                    }
                    else if (displayHandler.ListView.SelectedItems[0].ETag().Type == "file")
                    {
                        ProcessCall.RunProcess("explorer.exe", Path.GetDirectoryName(displayHandler.ListView.SelectedItems[0].ETag().Path));
                    }
                }
            };

            saveSelectionTool.Click += (sender, e) => 
            {
                if (!displayHandler.Focused) return;
                if (displayHandler.isSelected())
                {
                    displayHandler.SavedSelection.Clear();
                    foreach (ListViewItem listitem in displayHandler.ListView.SelectedItems)
                    {
                        displayHandler.SavedSelection.Add(listitem.Index);
                    }
                    displayHandler.SavedSelectionPath = displayHandler.RootDirectory.Path;
                }
            };

            restoreSelectionTool.Click += (sender, e) =>
            {
                if (!displayHandler.Focused) return;
                if (displayHandler.SavedSelectionPath == displayHandler.RootDirectory.Path)
                {
                    displayHandler.ListView.SelectedItems.Clear();
                    foreach (int index in displayHandler.SavedSelection)
                    {
                        displayHandler.ListView.Items[index].Selected = true;
                    }
                }
            };

            saveSelectionToFileTool.Click += (sender, e) =>
            {
                if (!displayHandler.Focused) return;
                if (displayHandler.isSelected())
                {
                    saveSelectionFileDialog.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
                    saveSelectionFileDialog.FileName = "selection.txt";
                    saveSelectionFileDialog.Filter = ".txt file (*.txt)|*.txt";

                    if (saveSelectionFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string savepath = saveSelectionFileDialog.FileName;
                        List<string> target = displayHandler.ListView.SelectedItems.Cast<ListViewItem>().Select(item => item.Index.ToString()).ToList();
                        target.Insert(0, displayHandler.RootDirectory.Path);
                        System.IO.File.WriteAllLines(savepath, target);
                    }
                }
            };

            loadSelectionFromFileTool.Click += (sender, e) =>
            {
                if (!displayHandler.Focused) return;
                List<string> source = new List<string>();

                loadSelectionFileDialog.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
                loadSelectionFileDialog.Filter = ".txt files (*.txt)|*.txt|All files (*.*)|*.*";
                loadSelectionFileDialog.FileName = "selection.txt";

                if (loadSelectionFileDialog.ShowDialog() == DialogResult.OK)
                {
                    source = System.IO.File.ReadAllLines(loadSelectionFileDialog.FileName).ToList();
                }
                else return;
                
                if (source[0] == displayHandler.RootDirectory.Path)
                {
                    source.RemoveAt(0);
                    foreach (string s in source)
                    {
                        int index = Int32.Parse(s);
                        displayHandler.ListView.Items[index].Selected = true;
                    }
                }
            };
            quickAccessList.DoubleClick += (sender, e) => AccessDoubleClick(displayHandler, directoryHandler, fileWatcher); //focused
            FormClosed += (sender, e) => { SaveSettings(displayList); }; //SHOULD NOT BE FOCUSED


            Controllers["Refresh"].Click            += (sender, e) => Refresh(displayHandler, directoryHandler);
            Controllers["InvertSelection"].Click    += (sender, e) => displayHandler.InvertSelection(); //focused
            Controllers["QuickAccessAdd"].Click     += (sender, e) => AccessAdd(displayHandler); //focused
            Controllers["QuickAccessRemove"].Click  += (sender, e) => AccessRemove(); //SHOULD BE UNIQUE
            
            Controllers["SortName"].Click           += (sender, e) => Sort(SortType.name, displayHandler, directoryHandler); //focused
            Controllers["SortDate"].Click           += (sender, e) => Sort(SortType.date, displayHandler, directoryHandler); //focused
            Controllers["SortSize"].Click           += (sender, e) => Sort(SortType.size, displayHandler, directoryHandler); //focused
            Controllers["SortExtension"].Click      += (sender, e) => Sort(SortType.extension, displayHandler, directoryHandler); //focused
            Controllers["SortReversed"].Click       += (sender, e) => { if (displayHandler.Focused) displayHandler.SortReversed = reversedTool.Checked; Refresh(displayHandler, directoryHandler); };

            Controllers["OpenConsole"].Click        += (sender, e) => Console(displayHandler); //focused
            Controllers["OpenPowershell"].Click     += (sender, e) => PowerShell(displayHandler); //focused

            Controllers["ViewDetails"].Click        += (sender, e) => { displayHandler.setView(1); }; //focused
            Controllers["ViewSmallIcons"].Click     += (sender, e) => { displayHandler.setView(2); }; //focused
            Controllers["ViewList"].Click           += (sender, e) => { displayHandler.setView(3); }; //focused
            Controllers["ViewTiles"].Click          += (sender, e) => { displayHandler.setView(4); }; //focused

            Controllers["GoUp"].Click               += (sender, e) => GoUp(displayHandler, directoryHandler, fileWatcher); //focused
            Controllers["Print"].Click              += (sender, e) => Print(displayHandler); //focused
            Controllers["SearchFor"].Click          += (sender, e) => SearchFor(displayHandler, directoryHandler, fileWatcher); //focused (???)

            Controllers["ShowAllFiles"].Click       += (sender, e) => ShowAll(displayHandler, directoryHandler); //focused
            Controllers["ShowPrograms"].Click       += (sender, e) => ShowPrograms(displayHandler, directoryHandler); //focused
            Controllers["ShowCustom"].Click         += (sender, e) => ShowCustom(displayHandler, directoryHandler); //focused

            Controllers["CalculateSpace"].Click     += (sender, e) => CalculateSpace(displayHandler); //focused
            Controllers["MultiRename"].Click        += (sender, e) => { MultiRename(displayHandler, directoryHandler); }; //focused

            Controllers["SelectGroup"].Click        += (sender, e) => SetGroupSelection(displayHandler, directoryHandler, true); //focused
            Controllers["UnselectGroup"].Click      += (sender, e) => SetGroupSelection(displayHandler, directoryHandler, false); //focused

            Controllers["CreateTab"].Click          += (sender, e) => { displayHandler.CreateTab(false, Click, DoubleClick, directoryHandler, fileWatcher); }; //focused
            Controllers["DeleteTab"].Click          += (sender, e) => { displayHandler.DeleteTab(); }; //focused

            Controllers["SelectAll"].Click          += (sender, e) => displayHandler.SetSelection(true); //focused
            Controllers["UnelectAll"].Click         += (sender, e) => displayHandler.SetSelection(false); //focused
            Controllers["SelectExtensions"].Click   += (sender, e) => displayHandler.SelectAllWithTheSameExtension(); //focused
            Controllers["ClipSelected"].Click       += (sender, e) => displayHandler.CopyNamesToClipboard(false, false); //focused
            Controllers["ClipWithPath"].Click       += (sender, e) => displayHandler.CopyNamesToClipboard(true, false); //focused
            Controllers["ClipWithExtensions"].Click += (sender, e) => displayHandler.CopyNamesToClipboard(false, true); //focused
            Controllers["ClipPathExtensions"].Click += (sender, e) => displayHandler.CopyNamesToClipboard(true, true); //focused



            // BOTTOM TAB - REPLACE WITH TOP STRIP SEPARATE BUTTONS
            refreshTool.Click += (sender, e) => { Refresh(displayHandler, directoryHandler); };
            Controllers["Rename"].Click             += (sender, e) => { Rename(displayHandler, directoryHandler); }; //focused //watched
            Controllers["View"].Click               += (sender, e) => { DoubleClick(displayHandler, directoryHandler, fileWatcher); }; //focused
            Controllers["Edit"].Click               += (sender, e) => { if (displayHandler.Focused) if (displayHandler.isSelected()) displayHandler.ListView.SelectedItems[0].ETag().Edit(); };
            Controllers["Copy"].Click               += (sender, e) => { if (displayHandler.Focused) exchangeBuffer.Copy(displayHandler.ListView.SelectedItems); exchangeBuffer.Cut = false; };
            Controllers["Cut"].Click                += (sender, e) => { if (displayHandler.Focused) exchangeBuffer.Copy(displayHandler.ListView.SelectedItems); exchangeBuffer.Cut = true; };
            Controllers["Paste"].Click              += (sender, e) => { if (displayHandler.Focused) exchangeBuffer.Paste(directoryHandler.RootDirectory.Path); }; //watched
            Controllers["NewFolder"].Click          += (sender, e) => { if (displayHandler.Focused) Directory.CreatePrompt(directoryHandler.RootDirectory.Path); }; //watched
            Controllers["Delete"].Click             += (sender, e) => { displayHandler.DeleteSelection(); }; //focused //watched
            //



            deleteAfterUnzipTool.Click += (sender, e) => { directoryHandler.DeleteSource = deleteAfterUnzipTool.Checked; }; //SHOULD BE UNIQUE
            compareFilenamesTool.Click += (sender, e) => CompareFilenames(displayHandler); //SHOULD NOT BE FOCUSED


            packTool.Click += (sender, e) => { if (displayHandler.Focused) directoryHandler.ZipArchive(displayHandler.ListView.SelectedItems); }; //NOT focused
            unpackAllTool.Click += (sender, e) => { if (displayHandler.Focused) directoryHandler.UnzipArchive(displayHandler.ListView.SelectedItems); }; //NOT focused
            unpackSpecificTool.Click += (sender, e) => { throw new Exception(); }; // TODO

            notepadTool.Click += (sender, e) => { if (displayHandler.Focused) ProcessCall.RunProcess("notepad", ""); }; //NOT focused
            goToSelectedPathButton.Click += (sender, e) => { GoToSelected(displayHandler, directoryHandler, fileWatcher); }; //focused

            displayHandler.ComboBox.SelectionChangeCommitted += (sender, e) =>
            {
                if (!displayHandler.Focused) return;
                directoryHandler.RootDirectory.Path = displayHandler.ComboBox.SelectedItem.ToString();
                displayHandler.TabControl.SelectedTab.Tag = directoryHandler.RootDirectory.Path;
                Refresh(displayHandler, directoryHandler);
            };

            // FORM EVENTS

            void SetData(DisplayHandler displayHandler)
            {
                Focus(displayHandler); displayHandler.SelectDrive();
                showHiddenFoldersTool.Checked = displayHandler.ShowHidden;
                showExtensionsTool.Checked = displayHandler.ShowExtensions;
            }

            displayHandler.ListView.MouseDown += (sender, e) => SetData(displayHandler);
            displayHandler.TabControl.MouseDown += (sender, e) => SetData(displayHandler);
            displayHandler.ListView.MouseDown += (sender, e) => { if (e.Button == MouseButtons.Right) ShowContext(); };

            // DISPLAY HANDLER EVENTS
            displayHandler.ListView.MouseClick += (sender, e) => {
                if (e.Button == MouseButtons.Left) Click(displayHandler, directoryHandler);
                if (e.Button == MouseButtons.Right) ShowContext();
            };

            displayHandler.ListView.MouseDoubleClick += (sender, e) => {
                if (e.Button == MouseButtons.Left) DoubleClick(displayHandler, directoryHandler, fileWatcher);
            };

            displayHandler.ListView.SelectedIndexChanged += (sender, e) => Click(displayHandler, directoryHandler);
            displayHandler.ListView.SelectedIndexChanged += (sender, e) => displayHandler.getFileInfo();

            displayHandler.TabControl.SelectedIndexChanged += (sender, e) =>
            {
                Focus(displayHandler);
                displayHandler.getFileInfo();
                displayHandler.CreateTab(true, Click, DoubleClick, directoryHandler, fileWatcher);
                if (System.IO.Directory.Exists(displayHandler.TabControl.SelectedTab.Tag!.ToString()!))
                {
                    directoryHandler.RootDirectory.Path = displayHandler.TabControl.SelectedTab.Tag!.ToString()!;
                    displayHandler.ListView = (ListView)displayHandler.TabControl.SelectedTab.Controls[0];
                    Refresh(displayHandler, directoryHandler);
                }
            };

            // SHOW TAB
            showHiddenFoldersTool.Click += (sender, e) =>
            {
                if (displayHandler.Focused) displayHandler.ShowHidden = showHiddenFoldersTool.Checked;
                Refresh(displayHandler, directoryHandler);
            };
            showExtensionsTool.Click += (sender, e) =>
            {
                if (displayHandler.Focused) displayHandler.ShowExtensions = showExtensionsTool.Checked;
                Refresh(displayHandler, directoryHandler);
            };
            //



            // TOOL STRIP

            displayHandler.TextBox.TextChanged += (sender, e) =>
            {
                foreach (ListViewItem listitem in displayHandler.ListView.Items)
                {
                    if (listitem.ETag().IgnoreListing == false)
                    {
                        if (listitem != null)
                        {
                            if (listitem.Text.ToLower().Contains(displayHandler.TextBox.Text.ToLower())
                            && !displayHandler.TextBox.Text.Trim().Equals(""))
                            {
                                int n = displayHandler.ListView.Items.IndexOf(listitem);
                                displayHandler.ListView.Items.RemoveAt(n);
                                displayHandler.ListView.Items.Insert(1, listitem);
                                listitem.ForeColor = Color.Black;
                            }
                            else if (displayHandler.TextBox.Text.Trim().Equals(""))
                            {
                                listitem.ForeColor = Color.Black;
                                Refresh(displayHandler, directoryHandler);
                                break;
                            }
                            else
                            {
                                listitem.ForeColor = Color.Gray;
                            }
                        }
                    }
                }
            };

        }
    }
}
