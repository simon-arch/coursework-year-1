namespace filemanager
{
    public partial class Manager
    {
        private void InitializeSharedEvents(Mediator mediator)
        {
            FormClosed  += (sender, e) => SaveSettings(displayList); //SHOULD NOT BE FOCUSED

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
            
            goToSelectedPathButton.Click += (sender, e) => mediator.GoToSelected(selectPathTextBox.Text);

            deleteAfterUnzipTool.CheckStateChanged += (sender, e) => { mediator.Navigator.DeleteSource = deleteAfterUnzipTool.Checked; };

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
                if (mediator.IsDisplayFocused()) mediator.Display.ShowHidden = showHiddenFoldersTool.Checked;
                mediator.Refresh();
            };
            showExtensionsTool.Click += (sender, e) =>
            {
                if (mediator.IsDisplayFocused()) mediator.Display.ShowExtensions = showExtensionsTool.Checked;
                mediator.Refresh();
            };
            //

            // TOOL STRIP

            mediator.Display.TextBox.TextChanged += (sender, e) => mediator.SearchInList();
        }
    }
}
