namespace filemanager
{
    public partial class Form1 : Form
    {
        DirectoryHandler directoryHandlerRightScreen = new DirectoryHandler();
        DirectoryHandler directoryHandlerLeftScreen = new DirectoryHandler();

        DisplayHandler displayHandlerRightScreen = new DisplayHandler();
        DisplayHandler displayHandlerLeftScreen = new DisplayHandler();

        List<DirectoryHandler> directoryList = new List<DirectoryHandler>();
        List<DisplayHandler> displayList = new List<DisplayHandler>();

        ExchangeBuffer exchangeBuffer = new ExchangeBuffer();
        LoggerHandler loggerHandler = new LoggerHandler();

        public Form1()
        {
            InitializeComponent();

            displayList.Add(displayHandlerLeftScreen);
            displayList.Add(displayHandlerRightScreen);

            directoryList.Add(directoryHandlerLeftScreen);
            directoryList.Add(directoryHandlerRightScreen);

            InitializeHandlers(displayHandlerLeftScreen, listView1, tabControl1, driveComboBox,
            selectedFileSizeLabel, freeSpaceLabel, imagePreviewBox, fileIconList, progressBar,
            previewBoxTabControl, searchTextBox);
            InitializeSharedEvents(displayHandlerLeftScreen, directoryHandlerLeftScreen);

            InitializeHandlers(displayHandlerRightScreen, listView2, tabControl2, driveComboBox,
            selectedFileSizeLabel, freeSpaceLabel, imagePreviewBox, fileIconList, progressBar,
            previewBoxTabControl, searchTextBox);
            InitializeSharedEvents(displayHandlerRightScreen, directoryHandlerRightScreen);

            LoadSettings(displayList, directoryList);
            InitializeUniqueEvents();

            loggerHandler.rtb = logTextBox;
            displayList[0].Focused = true;
            quickAccessList.Columns.Add("Quick Access", -2, HorizontalAlignment.Left);
            quickAccessList.SmallImageList = fileIconList;
            displayList.ForEach(x => x.SortType = "name");
            loggerHandler.Log(Category.start);

            Refresh(displayHandlerLeftScreen, directoryHandlerLeftScreen);
            Refresh(displayHandlerRightScreen, directoryHandlerRightScreen);
        }
    }
}