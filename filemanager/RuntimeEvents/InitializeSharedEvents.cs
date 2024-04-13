namespace filemanager
{
    public partial class Manager
    {
        private void InitializeSharedEvents(DisplayHandler displayHandler, DirectoryHandler directoryHandler)
        {

            quickAccessAddTool.Click += (sender, e) => AccessAdd(displayHandler);
            quickAccessRemoveTool.Click += (sender, e) => AccessRemove();
            quickAccessList.DoubleClick += (sender, e) => AccessDoubleClick(displayHandler, directoryHandler);
            sortNameTool.Click += (sender, e) => Sort(SortType.name, displayHandler, directoryHandler);
            sortDateTool.Click += (sender, e) => Sort(SortType.date, displayHandler, directoryHandler);
            sortSizeTool.Click += (sender, e) => Sort(SortType.size, displayHandler, directoryHandler);
            sortExtensionTool.Click += (sender, e) => Sort(SortType.extension, displayHandler, directoryHandler);
            deleteAfterUnzipTool.Click += (sender, e) => { directoryHandler.DeleteSource = deleteAfterUnzipTool.Checked; };
            openConsoleTool.Click += (sender, e) => Console(displayHandler);
            openPowershellTool.Click += (sender, e) => PowerShell(displayHandler);
            goUpTool.Click += (sender, e) => GoUp(displayHandler, directoryHandler);
            compareFilenamesTool.Click += (sender, e) => CompareFilenames(displayHandler);
            multiRenameTool.Click += (sender, e) => MultiRename(displayHandler, directoryHandler);
            listViewSetView1.Click += (sender, e) => { if (displayHandler.Focused) displayHandler.setView(1); };
            listViewSetView2.Click += (sender, e) => { if (displayHandler.Focused) displayHandler.setView(2); };
            listViewSetView3.Click += (sender, e) => { if (displayHandler.Focused) displayHandler.setView(3); };
            listViewSetView4.Click += (sender, e) => { if (displayHandler.Focused) displayHandler.setView(4); };
            invertSelectionTool.Click += (sender, e) => { if (displayHandler.Focused) displayHandler.InvertSelection(); };
            zipTool.Click += (sender, e) => { if (displayHandler.Focused) directoryHandler.ZipArchive(displayHandler.ListView.SelectedItems); };
            unzipTool.Click += (sender, e) => { if (displayHandler.Focused) directoryHandler.UnzipArchive(displayHandler.ListView.SelectedItems); };
            searchTool.Click += (sender, e) => SearchFor(displayHandler, directoryHandler);
            notepadTool.Click += (sender, e) => { if (displayHandler.Focused) ProcessCall.RunProcess("notepad", ""); };
            goToSelectedPathButton.Click += (sender, e) => GoToSelected(displayHandler, directoryHandler);

            displayHandler.ComboBox.SelectionChangeCommitted += (sender, e) =>
            {
                if (displayHandler.Focused)
                {
                    directoryHandler.RootDirectory.Path = displayHandler.ComboBox.SelectedItem.ToString();
                    displayHandler.TabControl.SelectedTab.Tag = directoryHandler.RootDirectory.Path;
                    Refresh(displayHandler, directoryHandler);
                }
            };

            printTool.Click += (sender, e) => Print(displayHandler);
            propertiesTool.Click += (sender, e) => Properties(displayHandler);
            showAllFilesTool.Click += (sender, e) => ShowAll(displayHandler, directoryHandler);
            showProgramsTool.Click += (sender, e) => ShowPrograms(displayHandler, directoryHandler);
            showCustomTool.Click += (sender, e) => ShowCustom(displayHandler, directoryHandler);
            calculateSpaceTool.Click += (sender, e) => CalculateSpace(displayHandler);


            // FORM EVENTS
            this.FormClosed += (sender, e) => { SaveSettings(displayList); };

            displayHandler.ListView.Click += (sender, e) => { Focus(displayHandler); displayHandler.SelectDrive(); };
            displayHandler.TabControl.Click += (sender, e) => { Focus(displayHandler); displayHandler.SelectDrive(); };
            // // // // // // // // // // // //

            // DISPLAY HANDLER EVENTS
            displayHandler.ListView.Click += (sender, e) => { Click(displayHandler, directoryHandler); };
            displayHandler.ListView.DoubleClick += (sender, e) => { DoubleClick(displayHandler, directoryHandler); };
            displayHandler.ListView.SelectedIndexChanged += (sender, e) => { Click(displayHandler, directoryHandler); };
            displayHandler.ListView.SelectedIndexChanged += (sender, e) => { displayHandler.getFileInfo(); };

            displayHandler.TabControl.SelectedIndexChanged += (sender, e) =>
            {
                displayHandler.getFileInfo();
                displayHandler.CreateTab(true, Click, DoubleClick, directoryHandler);
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
            showHiddenFoldersTool.Click += (sender, e) => { if (displayHandler.Focused) displayHandler.ShowHidden = showHiddenFoldersTool.Checked; Refresh(displayHandler, directoryHandler); };
            showExtensionsTool.Click += (sender, e) => { if (displayHandler.Focused) displayHandler.ShowExtensions = showExtensionsTool.Checked; Refresh(displayHandler, directoryHandler); };
            //

            // TABS TAB
            createTabTool.Click += (sender, e) => { if (displayHandler.Focused) displayHandler.CreateTab(false, Click, DoubleClick, directoryHandler); };
            deleteTabTool.Click += (sender, e) => { if (displayHandler.Focused) displayHandler.DeleteTab(); };
            //

            // MARK TAB
            selectAllTool.Click += (sender, e) => { if (displayHandler.Focused) displayHandler.SelectAll(); };
            unselectAllTool.Click += (sender, e) => { if (displayHandler.Focused) displayHandler.UnselectAll(); };
            selectAllWithTheSameExtensionTool.Click += (sender, e) => { if (displayHandler.Focused) displayHandler.SelectAllWithTheSameExtension(); };
            copySelectedNamesToClipboardTool.Click += (sender, e) => { if (displayHandler.Focused) displayHandler.CopyNamesToClipboard(false); };
            copyNamesWithPathToClipboardTool.Click += (sender, e) => { if (displayHandler.Focused) displayHandler.CopyNamesToClipboard(true); };
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
            renameTool.Click += (sender, e) => Rename(displayHandler, directoryHandler);
            viewTool.Click += (sender, e) => { DoubleClick(displayHandler, directoryHandler); };
            editTool.Click += (sender, e) => { if (displayHandler.isSelected()) ((Element)displayHandler.ListView.SelectedItems[0].Tag).Edit(); };
            copyTool.Click += (sender, e) => { exchangeBuffer.Copy(displayHandler.ListView.SelectedItems); exchangeBuffer.Cut = false; };
            cutTool.Click += (sender, e) => { exchangeBuffer.Copy(displayHandler.ListView.SelectedItems); exchangeBuffer.Cut = true; };
            pasteTool.Click += (sender, e) => { exchangeBuffer.Paste(directoryHandler.RootDirectory.Path); Refresh(displayHandler, directoryHandler); };
            newFolderTool.Click += (sender, e) => { Directory.CreatePrompt(directoryHandler.RootDirectory.Path); Refresh(displayHandler, directoryHandler); };
            deleteTool.Click += (sender, e) => { displayHandler.DeleteSelection(); Refresh(displayHandler, directoryHandler); };
            exitTool.Click += (sender, e) => { Close(); };
            //
        }
    }
}
