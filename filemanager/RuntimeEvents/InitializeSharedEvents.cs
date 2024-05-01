using filemanager.Dialogs;

namespace filemanager
{
    public partial class Manager
    {
        private void InitializeSharedEvents(Mediator mediator)
        {
            FormClosed  += (sender, e) => SaveSettings(displayList); //SHOULD NOT BE FOCUSED

            Controllers["QuickAccessAdd"].Click += (sender, e) => AccessAdd(mediator.Display); //focused
            Controllers["QuickAccessRemove"].Click += (sender, e) => AccessRemove(); //SHOULD BE UNIQUE
            quickAccessList.DoubleClick += (sender, e) => AccessDoubleClick(mediator); //focused
            quickAccessList.MouseClick += (sender, e) => { if (e.Button == MouseButtons.Right) ShowQuickContext(); };

            mediator.Display.ListView.ColumnClick += (sender, e) =>
            {
                Focus(mediator.Display);
                if ((SortType)e.Column == mediator.Display.SortType)
                    mediator.ReverseSort(!mediator.Display.SortReversed);
                switch (e.Column)
                {
                    case 0: mediator.Sort(SortType.name);       break;
                    case 1: mediator.Sort(SortType.extension);  break;
                    case 2: mediator.Sort(SortType.size);       break;
                    case 3: mediator.Sort(SortType.date);       break;
                }
            };

            /* refactored */ Controllers["ChangeAttributes"].Click   += (sender, e) => mediator.ChangeAttributes();
            /* refactored */ Controllers["OpenInExplorer"].Click     += (sender, e) => mediator.Display.OpenInExplorer();
            /* refactored */ Controllers["SaveSelection"].Click      += (sender, e) => mediator.Display.SaveSelection();
            /* refactored */ Controllers["RestoreSelection"].Click   += (sender, e) => mediator.Display.RestoreSelection();
            /* refactored */ Controllers["SelectionToFile"].Click    += (sender, e) => mediator.Display.SelectionToFile();
            /* refactored */ Controllers["LoadSelectionFile"].Click  += (sender, e) => mediator.Display.LoadSelectionFromFile();
            /* refactored */ Controllers["InvertSelection"].Click    += (sender, e) => mediator.Display.InvertSelection(); //focused
            
            /* refactored */ Controllers["SortName"].Click           += (sender, e) => mediator.Sort(SortType.name); //focused
            /* refactored */ Controllers["SortDate"].Click           += (sender, e) => mediator.Sort(SortType.date); //focused
            /* refactored */ Controllers["SortSize"].Click           += (sender, e) => mediator.Sort(SortType.size); //focused
            /* refactored */ Controllers["SortExtension"].Click      += (sender, e) => mediator.Sort(SortType.extension); //focused
            /* refactored */ Controllers["SortReversed"].Click       += (sender, e) => mediator.ReverseSort(reversedTool.Checked); //focused

            /* refactored */ Controllers["OpenConsole"].Click        += (sender, e) => mediator.Display.Console(); //focused
            /* refactored */ Controllers["OpenPowershell"].Click     += (sender, e) => mediator.Display.PowerShell(); //focused

            /* refactored */ Controllers["ViewDetails"].Click        += (sender, e) => mediator.Display.setView(1); //focused
            /* refactored */ Controllers["ViewSmallIcons"].Click     += (sender, e) => mediator.Display.setView(2); //focused
            /* refactored */ Controllers["ViewList"].Click           += (sender, e) => mediator.Display.setView(3); //focused
            /* refactored */ Controllers["ViewTiles"].Click          += (sender, e) => mediator.Display.setView(4); //focused

            /* refactored */ Controllers["GoUp"].Click               += (sender, e) => mediator.GoUp(); //focused
            /* refactored */ Controllers["Print"].Click              += (sender, e) => mediator.Display.Print(); //focused
            /* refactored */ Controllers["SearchFor"].Click          += (sender, e) => mediator.SearchFor(); //focused (???)

            /* refactored */ Controllers["ShowAllFiles"].Click       += (sender, e) => mediator.ShowAll(); //focused
            /* refactored */ Controllers["ShowPrograms"].Click       += (sender, e) => mediator.ShowPrograms(); //focused
            /* refactored */ Controllers["ShowCustom"].Click         += (sender, e) => mediator.ShowCustom(); //focused

            /* refactored */ Controllers["CalculateSpace"].Click     += (sender, e) => mediator.Display.CalculateSpace(); //focused
            /* refactored */ Controllers["MultiRename"].Click        += (sender, e) => mediator.Display.MultiRename(); //focused

            /* refactored */ Controllers["SelectGroup"].Click        += (sender, e) => mediator.Display.SetGroupSelection(true); //focused
            /* refactored */ Controllers["UnselectGroup"].Click      += (sender, e) => mediator.Display.SetGroupSelection(false); //focused

            /* refactored */ Controllers["CreateTab"].Click          += (sender, e) => mediator.Display.CreateTab(false, Click, mediator.DoubleClick, associated); //focused
            /* refactored */ Controllers["DeleteTab"].Click          += (sender, e) => mediator.Display.DeleteTab(); //focused

            /* refactored */ Controllers["SelectAll"].Click          += (sender, e) => mediator.Display.SetSelection(true); //focused
            /* refactored */ Controllers["UnselectAll"].Click         += (sender, e) => mediator.Display.SetSelection(false); //focused
            /* refactored */ Controllers["SelectExtensions"].Click   += (sender, e) => mediator.Display.SelectAllWithTheSameExtension(); //focused
            /* refactored */ Controllers["ClipSelected"].Click       += (sender, e) => mediator.Display.CopyNamesToClipboard(false, false); //focused
            /* refactored */ Controllers["ClipWithPath"].Click       += (sender, e) => mediator.Display.CopyNamesToClipboard(true, false); //focused
            /* refactored */ Controllers["ClipWithExtensions"].Click += (sender, e) => mediator.Display.CopyNamesToClipboard(false, true); //focused
            /* refactored */ Controllers["ClipPathExtensions"].Click += (sender, e) => mediator.Display.CopyNamesToClipboard(true, true); //focused

            /* refactored */ Controllers["Refresh"].Click            += (sender, e) => mediator.Refresh();
            /* refactored */ Controllers["Rename"].Click             += (sender, e) => mediator.Display.Rename(); //focused //watched
            /* refactored */ Controllers["View"].Click               += (sender, e) => mediator.DoubleClick(associated); //focused
            /* refactored */ Controllers["Edit"].Click               += (sender, e) => mediator.Edit();
            Controllers["Copy"].Click               += (sender, e) => { if (mediator.Display.Focused) exchangeBuffer.Copy(mediator.Display.ListView.SelectedItems); exchangeBuffer.Cut = false; };
            Controllers["Cut"].Click                += (sender, e) => { if (mediator.Display.Focused) exchangeBuffer.Copy(mediator.Display.ListView.SelectedItems); exchangeBuffer.Cut = true; };
            Controllers["Paste"].Click              += (sender, e) => { if (mediator.Display.Focused) exchangeBuffer.Paste(mediator.Navigator.RootDirectory.Path); }; //watched
            /* refactored */ Controllers["NewFolder"].Click          += (sender, e) => mediator.NewFolder(); //watched
            /* refactored */ Controllers["Delete"].Click             += (sender, e) => mediator.Display.DeleteSelection(); //focused //watched
            //

            Controllers["CompareNames"].Click       += (sender, e) => CompareFilenames(mediator.Display); //SHOULD NOT BE FOCUSED
            /* refactored */ Controllers["PackZip"].Click            += (sender, e) => mediator.ZipSelected(); //NOT focused
            /* refactored */ Controllers["UnpackAll"].Click          += (sender, e) => mediator.UnzipSelected(); //NOT focused


            deleteAfterUnzipTool.CheckStateChanged += (sender, e) => { mediator.Navigator.DeleteSource = deleteAfterUnzipTool.Checked; }; //SHOULD BE UNIQUE
            /* refactored */ goToSelectedPathButton.Click += (sender, e) => mediator.GoToSelected(selectPathTextBox.Text); //focused

            mediator.Display.ComboBox.SelectionChangeCommitted += (sender, e) =>
            {
                if (!mediator.Display.Focused) return;
                mediator.Navigator.RootDirectory.Path = mediator.Display.ComboBox.SelectedItem.ToString();
                mediator.Display.TabControl.SelectedTab.Tag = mediator.Navigator.RootDirectory.Path;
                mediator.Refresh();
            };

            // FORM EVENTS

            void SetData(Mediator mediator)
            {
                Focus(mediator.Display); mediator.Display.SelectDrive();
                showHiddenFoldersTool.Checked = mediator.Display.ShowHidden;
                showExtensionsTool.Checked = mediator.Display.ShowExtensions;
            }

            mediator.Display.ListView.MouseDown   += (sender, e) => SetData(mediator);
            mediator.Display.TabControl.MouseDown += (sender, e) => SetData(mediator);
            mediator.Display.ListView.MouseDown   += (sender, e) => { if (e.Button == MouseButtons.Right) ShowContext(); };

            // DISPLAY HANDLER EVENTS
            mediator.Display.ListView.MouseClick += (sender, e) => {
                if (e.Button == MouseButtons.Left) Click(mediator.Display);
                if (e.Button == MouseButtons.Right) ShowContext();
            };

            mediator.Display.ListView.MouseDoubleClick += (sender, e) => {
                if (e.Button == MouseButtons.Left) mediator.DoubleClick(associated);
            };

            mediator.Display.ListView.SelectedIndexChanged += (sender, e) => Click(mediator.Display);
            mediator.Display.ListView.SelectedIndexChanged += (sender, e) => mediator.Display.getFileInfo();

            mediator.Display.TabControl.SelectedIndexChanged += (sender, e) =>
            {
                Focus(mediator.Display);
                mediator.Display.getFileInfo();
                mediator.Display.CreateTab(true, Click, mediator.DoubleClick, associated);
                if (System.IO.Directory.Exists(mediator.Display.TabControl.SelectedTab.Tag!.ToString()!))
                {
                    mediator.Navigator.RootDirectory.Path = mediator.Display.TabControl.SelectedTab.Tag!.ToString()!;
                    mediator.Display.ListView = (ListView)mediator.Display.TabControl.SelectedTab.Controls[0];
                    mediator.Refresh();
                }
            };

            // SHOW TAB
            showHiddenFoldersTool.Click += (sender, e) =>
            {
                if (mediator.Display.Focused) mediator.Display.ShowHidden = showHiddenFoldersTool.Checked;
                mediator.Refresh();
            };
            showExtensionsTool.Click += (sender, e) =>
            {
                if (mediator.Display.Focused) mediator.Display.ShowExtensions = showExtensionsTool.Checked;
                mediator.Refresh();
            };
            //



            // TOOL STRIP

            /* refactored */ mediator.Display.TextBox.TextChanged += (sender, e) => mediator.SearchInList();
        }
    }
}
