namespace filemanager
{
    public partial class Manager
    {
        private void InitializeSharedEvents(DisplayHandler displayHandler, DirectoryHandler directoryHandler, FileWatcher fileWatcher)
        {

            quickAccessAddTool.Click += (sender, e) => AccessAdd(displayHandler); //focused
            quickAccessRemoveTool.Click += (sender, e) => AccessRemove(); //SHOULD BE UNIQUE
            quickAccessList.DoubleClick += (sender, e) => AccessDoubleClick(displayHandler, directoryHandler, fileWatcher); //focused
            sortNameTool.Click += (sender, e) => Sort(SortType.name, displayHandler, directoryHandler); //focused
            sortDateTool.Click += (sender, e) => Sort(SortType.date, displayHandler, directoryHandler); //focused
            sortSizeTool.Click += (sender, e) => Sort(SortType.size, displayHandler, directoryHandler); //focused
            sortExtensionTool.Click += (sender, e) => Sort(SortType.extension, displayHandler, directoryHandler); //focused
            deleteAfterUnzipTool.Click += (sender, e) => { directoryHandler.DeleteSource = deleteAfterUnzipTool.Checked; }; //SHOULD BE UNIQUE
            openConsoleTool.Click += (sender, e) => Console(displayHandler); //focused
            openPowershellTool.Click += (sender, e) => PowerShell(displayHandler); //focused
            goUpTool.Click += (sender, e) => GoUp(displayHandler, directoryHandler, fileWatcher); //focused
            compareFilenamesTool.Click += (sender, e) => CompareFilenames(displayHandler); //SHOULD NOT BE FOCUSED
            multiRenameTool.Click += (sender, e) => { MultiRename(displayHandler, directoryHandler); }; //focused
            listViewSetView1.Click += (sender, e) => { displayHandler.setView(1); }; //focused
            listViewSetView2.Click += (sender, e) => { displayHandler.setView(2); }; //focused
            listViewSetView3.Click += (sender, e) => { displayHandler.setView(3); }; //focused
            listViewSetView4.Click += (sender, e) => { displayHandler.setView(4); }; //focused
            invertSelectionTool.Click += (sender, e) => { displayHandler.InvertSelection(); }; //focused
            zipTool.Click += (sender, e) => { if (displayHandler.Focused) directoryHandler.ZipArchive(displayHandler.ListView.SelectedItems); }; //NOT focused
            unzipTool.Click += (sender, e) => { if (displayHandler.Focused) directoryHandler.UnzipArchive(displayHandler.ListView.SelectedItems); }; //NOT focused
            searchTool.Click += (sender, e) => SearchFor(displayHandler, directoryHandler, fileWatcher); //focused (???)
            notepadTool.Click += (sender, e) => { if (displayHandler.Focused) ProcessCall.RunProcess("notepad", ""); }; //NOT focused
            goToSelectedPathButton.Click += (sender, e) => { GoToSelected(displayHandler, directoryHandler, fileWatcher); }; //focused

            displayHandler.ComboBox.SelectionChangeCommitted += (sender, e) =>
            {
                if (!displayHandler.Focused) return;
                directoryHandler.RootDirectory.Path = displayHandler.ComboBox.SelectedItem.ToString();
                displayHandler.TabControl.SelectedTab.Tag = directoryHandler.RootDirectory.Path;
                Refresh(displayHandler, directoryHandler);
            };

            printTool.Click += (sender, e) => Print(displayHandler); //focused
            propertiesTool.Click += (sender, e) => Properties(displayHandler);//focused
            showAllFilesTool.Click += (sender, e) => ShowAll(displayHandler, directoryHandler); //focused
            showProgramsTool.Click += (sender, e) => ShowPrograms(displayHandler, directoryHandler); //focused
            showCustomTool.Click += (sender, e) => ShowCustom(displayHandler, directoryHandler); //focused
            calculateSpaceTool.Click += (sender, e) => CalculateSpace(displayHandler); //focused

            //

            selectGroupTool.Click += (sender, e) => SetGroupSelection(displayHandler, directoryHandler, true); //focused
            unselectGroupTool.Click += (sender, e) => SetGroupSelection(displayHandler, directoryHandler, false); //focused

            // FORM EVENTS
            this.FormClosed += (sender, e) => { SaveSettings(displayList); }; //SHOULD NOT BE FOCUSED

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
                MouseEventArgs me = (MouseEventArgs)e;
                if (me.Button == MouseButtons.Left) 
                { 
                    Click(displayHandler, directoryHandler); 
                }
                if (me.Button == MouseButtons.Right) 
                {
                    ShowContext(displayHandler, directoryHandler);
                }
            };

            displayHandler.ListView.MouseDoubleClick += (sender, e) => {
                MouseEventArgs me = (MouseEventArgs)e;
                if (me.Button == MouseButtons.Left)
                {
                    DoubleClick(displayHandler, directoryHandler, fileWatcher);
                }
            };
            
            displayHandler.ListView.SelectedIndexChanged += (sender, e) => { Click(displayHandler, directoryHandler); };
            displayHandler.ListView.SelectedIndexChanged += (sender, e) => { displayHandler.getFileInfo(); };

            displayHandler.TabControl.SelectedIndexChanged += (sender, e) =>
            {
                displayHandler.getFileInfo();
                displayHandler.CreateTab(true, Click, DoubleClick, directoryHandler, fileWatcher);
                if (System.IO.Directory.Exists(displayHandler.TabControl.SelectedTab.Tag!.ToString()!))
                {
                    directoryHandler.RootDirectory.Path = displayHandler.TabControl.SelectedTab.Tag!.ToString()!;
                    displayHandler.ListView = (ListView)displayHandler.TabControl.SelectedTab.Controls[0];
                    Refresh(displayHandler, directoryHandler);
                }
                else
                {
                    displayHandler.DeleteTab();
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

            // TABS TAB
            createTabTool.Click += (sender, e) => { displayHandler.CreateTab(false, Click, DoubleClick, directoryHandler, fileWatcher); }; //focused
            deleteTabTool.Click += (sender, e) => { displayHandler.DeleteTab(); }; //focused
            //

            // MARK TAB
            selectAllTool.Click += (sender, e) => displayHandler.SetSelection(true); //focused
            unselectAllTool.Click += (sender, e) => displayHandler.SetSelection(false); //focused
            selectAllWithTheSameExtensionTool.Click += (sender, e) => displayHandler.SelectAllWithTheSameExtension(); //focused
            copySelectedNamesToClipboardTool.Click += (sender, e) => displayHandler.CopyNamesToClipboard(false, false); //focused
            copyNamesWithPathToClipboardTool.Click += (sender, e) => displayHandler.CopyNamesToClipboard(true, false); //focused
            copyToClipboardWithExtensions.Click += (sender, e) => displayHandler.CopyNamesToClipboard(false, true); //focused
            copyToClipboardWithPathExtensions.Click += (sender, e) => displayHandler.CopyNamesToClipboard(true, true); //focused
            //

            // TOOL STRIP
            quickRefreshTool.Click += (sender, e) => { Refresh(displayHandler, directoryHandler); };

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
            // BOTTOM TAB
            refreshTool.Click += (sender, e) => { Refresh(displayHandler, directoryHandler); };
            renameTool.Click += (sender, e) => { Rename(displayHandler, directoryHandler); }; //focused //watched
            viewTool.Click += (sender, e) => { DoubleClick(displayHandler, directoryHandler, fileWatcher); }; //focused
            editTool.Click += (sender, e) => { if (displayHandler.Focused) if (displayHandler.isSelected()) displayHandler.ListView.SelectedItems[0].ETag().Edit(); };
            copyTool.Click += (sender, e) => { if (displayHandler.Focused) exchangeBuffer.Copy(displayHandler.ListView.SelectedItems); exchangeBuffer.Cut = false; };
            cutTool.Click += (sender, e) => { if (displayHandler.Focused) exchangeBuffer.Copy(displayHandler.ListView.SelectedItems); exchangeBuffer.Cut = true; };
            pasteTool.Click += (sender, e) => { if (displayHandler.Focused) exchangeBuffer.Paste(directoryHandler.RootDirectory.Path); }; //watched
            newFolderTool.Click += (sender, e) => { if (displayHandler.Focused) Directory.CreatePrompt(directoryHandler.RootDirectory.Path); }; //watched
            deleteTool.Click += (sender, e) => { displayHandler.DeleteSelection(); }; //focused //watched
            //
        }
    }
}
