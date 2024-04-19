namespace filemanager
{
    public partial class Manager : Form
    {
        DirectoryHandler directoryHandlerRightScreen = new DirectoryHandler();
        DirectoryHandler directoryHandlerLeftScreen = new DirectoryHandler();

        DisplayHandler displayHandlerRightScreen = new DisplayHandler();
        DisplayHandler displayHandlerLeftScreen = new DisplayHandler();

        FileWatcher watcherRightScreen = new FileWatcher();
        FileWatcher watcherLeftScreen = new FileWatcher();

        List<DirectoryHandler> directoryList = new List<DirectoryHandler>();
        List<DisplayHandler> displayList = new List<DisplayHandler>();
        List<FileWatcher> watcherList = new List<FileWatcher>();

        ExchangeBuffer exchangeBuffer = new ExchangeBuffer();
        LoggerHandler loggerHandler = new LoggerHandler();
        public Manager()
        {
            InitializeComponent();

            displayList.Add(displayHandlerLeftScreen);
            displayList.Add(displayHandlerRightScreen);

            directoryList.Add(directoryHandlerLeftScreen);
            directoryList.Add(directoryHandlerRightScreen);

            watcherList.Add(watcherLeftScreen);
            watcherList.Add(watcherRightScreen);

            watcherList[0].Init();
            watcherList[0].DisplayHandler = displayList[0];
            watcherList[0].DirectoryHandler = directoryList[0];
            watcherList[0].Form = this;
            watcherList[1].Init();
            watcherList[1].DisplayHandler = displayList[1];
            watcherList[1].DirectoryHandler = directoryList[1];
            watcherList[1].Form = this;

            InitializeHandlers(displayHandlerLeftScreen, listView1, tabControl1, driveComboBox,
            selectedFileSizeLabel, freeSpaceLabel, imagePreviewBox, fileIconList, progressBar,
            previewBoxTabControl, searchTextBox);
            InitializeSharedEvents(displayHandlerLeftScreen, directoryHandlerLeftScreen, watcherLeftScreen);

            InitializeHandlers(displayHandlerRightScreen, listView2, tabControl2, driveComboBox,
            selectedFileSizeLabel, freeSpaceLabel, imagePreviewBox, fileIconList, progressBar,
            previewBoxTabControl, searchTextBox);
            InitializeSharedEvents(displayHandlerRightScreen, directoryHandlerRightScreen, watcherRightScreen);

            LoadSettings(displayList, directoryList, watcherList);
            InitializeUniqueEvents();

            InitContextEvents(displayHandlerLeftScreen, directoryHandlerLeftScreen, watcherLeftScreen);
            InitContextEvents(displayHandlerRightScreen, directoryHandlerRightScreen, watcherRightScreen);

            loggerHandler.rtb = logTextBox;
            displayList[0].Focused = true;
            quickAccessList.SmallImageList = fileIconList;
            displayList.ForEach(x => x.SortType = SortType.name);
            loggerHandler.Log(LogCategory.start);

            DoubleBuffering.SetDoubleBuffering(displayList[0].ListView, true);
            DoubleBuffering.SetDoubleBuffering(displayList[1].ListView, true);

            Focus(displayList[0]); displayList[0].setView(1);
            Focus(displayList[1]); displayList[1].setView(1);

            Refresh(displayHandlerLeftScreen, directoryHandlerLeftScreen);
            Refresh(displayHandlerRightScreen, directoryHandlerRightScreen);
        }
    }
}