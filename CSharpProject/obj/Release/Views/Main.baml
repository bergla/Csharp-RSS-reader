   M S B A M L   `   `   `  ����   CSharpProject    CSharpProject.Views.Main   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  RSS Podcast Reader��$	��654��$��1219.5�� � 
ResizeMode$ NoResize=�.��� $��	0,0,76,-2q�.+��� -    ��Name$ imgTree_Copy��$
��Left=�$	��284��$��941,27,-74,0q�$	��Top=�$	��269��$0��*/CSharpProject;component/Graphics/tree.jpg���� $	��625��$	��Top=�$��	0,0,-74,0q�.@��� -    ��Name$ tabBtnSearch��$��Search��.��� -    �Name$ 	tabSearch��
�������$��0,0,-1,0q� � ColumnDefinitions �� .+��� -   $ imgTree��$
��Left=�$	��284��$��
940,0,-2,0q�$	��Top=�$	��269��$0��*/CSharpProject;component/Graphics/tree.jpg���� -   $ imageBanner��$
��Left=�$��97��$��	10,10,0,0q�$	��Top=�$	��598��$��/graphics/logo.png���� -    ��Name$ labelFeedName��$
��Left=�$��405,130,0,0q�$
��Wrap=�$��
Feed Name?��$	��Top=�$��Tempus Sans ITC)��� -   $ labelUrl��$
��Left=�$��
23,135,0,0q�$
��Wrap=�$��Feed Url��$	��Top=�$��Tempus Sans ITC)�$
��Bold"��� -    ��Name$ tbUrl��$
��Left=�$��23��$��
23,152,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��217��$��Tempus Sans ITC)��� -	   	 ��Name$	 btnGet��$��Get Feed��$
��Left=�$��245,152,0,0q�$	��Top=�$��75��$��23��$��Tempus Sans ITC)����	#FFFFD0D0$��2q��� -
   $	 btnAddFavorite��$��325,152,805,422q����	#FFFFD0D0$��2q�.��]� .+��� $��/graphics/bookmark.png��$��Uniform=��� $��Center=�$��Tempus Sans ITC)��� $�Favorite���� -   
 ��Name$
 lwFeed��$
��Left=�$	��310��$��
23,181,0,0q�$	��Top=�$	��863�� J� RenderTransformOrigin$ 0.699,0.523&����	#FFFFD0D0$��2q�$��Tempus Sans ITC)� �� View �� .P��� $��Title�� �� Width$	 300�� �� DisplayMemberBinding �� *Title+�� $
��Date��$	 150�� �� *Date+�� $��
Downloaded��$ 80�� �� *
Downloaded+�� $
��File��$	 320�� �� *File+�� -   $ 
tbFeedName��$
��Left=�$��23��$��405,152,0,0q�$
 Wrap=�$	��Top=�$	��146��$��Tempus Sans ITC)��� -   $	 btnFeedName��$��Add Favorite��$
��Left=�$��793,151,0,0q�$	��Top=�$��85��$��23�����	#FFFFD0D0$��2q�$��Tempus Sans ITC)��� -   $	 btnDL��$��Download��$
��Left=�$��802,495,0,0q�$	��Top=�$��84��$��23�� � ToolTip$$ Downloads the selected podcast��$��Tempus Sans ITC)����	#FFFFD0D0$��2q��� -    ��Name$ labelChannel��$�� ��$��Right=�$��
0,0,75,193q�$��Bottom=�$��47��$	��139��$��Tempus Sans ITC)�$��14(��� -    ��Name$ 	sliderVol��$
��Left=�$��20��$��1014,471,0,0q�$	��Top=�$��88�����	#00000000 � Maximum$ 1Q� � Value$	 0.5Q��� -   $	 btnPause��$
��Left=�$��1062,422,0,0q�$	��Top=�$��42��$��41�����	#FFFFD0D0$��2q�.���� $��/graphics/pause.png��$��Uniform=�$��1q��� -   $	 btnPlay��$
��Left=�$��1014,422,0,0q�$	��Top=�$��42��$��41�����	#FFFFD0D0$��2q�.���� $��/graphics/play.png��$��Uniform=�r� -    r�Name$ mediaPlayer��$
��Left=�$��40��$��	802,0,0,0q�$	��Top=�$��51�� r� LoadedBehavior$ Manual=� r� UnloadedBehavior$
 Stop=��� -   $ 
imgChannel��$
��Left=�$	��143��$��990,261,0,0q�$	��Top=�$	��140���� -    ��Name$ cbCatAddFav��$
��Left=�$��556,152,0,0q�$	��Top=�$	��139��$��23�� �� SelectedIndex$ 0���� -   $ labelAddFavSearch��$
��Left=�$��556,130,0,0q�$
��Wrap=�$��	Category?��$	��Top=�$��Tempus Sans ITC)��� -   $	 btnAddCatShow��$��New Category...��$
��Left=�$��629,132,0,0q�$	��Top=�$��66��$��Tempus Sans ITC)�$��8(����	#FFFFD0D0�� -   $ tbNewCat��$
��Left=�$��14��$��703,132,0,0q�$
 Wrap=�$	��Top=�$��85��$��8(�$��Tempus Sans ITC)��� -   $	 	btnAddCat��$��OK��$
��Left=�$��793,132,0,0q�$	��Top=�$��28��$��14��$��8(�$��Tempus Sans ITC)����	#FFFFD0D0�� -   $ labelInterval��$��Interval��$
��Left=�$��700,150,0,0q�$	��Top=�$��Tempus Sans ITC)��� -   $ tbInterval1��$
��Left=�$��23��$��753,151,0,0q�$
 Wrap=�$	��Top=�$��35���� -   $ label��$"��Play in Windows Media Player��$
��Left=�$��1014,544,0,0q�$	��Top=�$ -0.148,-0.092&��� -   $	 
btnPlayWMP��$
��Left=�$��972,535,0,0q�$	��Top=�$��42��$��41�����	#FFFFD0D0$��2q�.���� $��/graphics/play.png��$��Uniform=��� -   $ 
tabBtnFavs��$��	Favorites��.��� -   $ tabFavorites��
������� � RowDefinitions ��  �� .+��� -    $ cbFeeds��$
��Left=�$��
23,153,0,0q�$	��Top=�$	��192��$ 0��$��Tempus Sans ITC)�
���   �����  �� EndPoint$	 0,1&� �� 
StartPoint$	 0,0&�.���  � Color$ 	#FFF0F0F0�� � Offset$ 0Q�� $ 	#FFFFD0D0��$ 1Q��� -!   $
 	lwFavFeed��$
��Left=�$	��310��$��
23,180,0,0q�$	��Top=�$	��863��$ 0.699,0.523&����	#FFFFD0D0$��2q�$��Tempus Sans ITC)� �� .P��� $��Title��$	 300�� �� *Title+�� $
��Date��$	 150�� �� *Date+�� $��
Downloaded��$ 80�� �� *
Downloaded+�� $
��File��$	 325�� �� *File+�� -"   $ sliderVolFav��$
��Left=�$��20��$��928,470,0,0q�$	��Top=�$��88�����	#00000000$ 1Q�$	 0.5Q� � SmallChange$
 0.05Q��� -#   $	 btnPauseFav��$
��Left=�$��976,420,0,0q�$	��Top=�$��42��$��42�����	#FFFFD0D0$��2q�.���� $1��+/CSharpProject;component/Graphics/pause.png��$��Uniform=�$��1q��� -$   $	 
btnPlayFav��$
��Left=�$��928,420,0,0q�$	��Top=�$��42��$��42�����	#FFFFD0D0$��2q�.���� $0��*/CSharpProject;component/Graphics/play.png��$��Uniform=��� -%   $ labelFav��$
��Left=�$��
23,132,0,0q�$
��Wrap=�$��	Favorites��$	��Top=�$��Tempus Sans ITC)��� -&   $ labelCat��$
��Left=�$��252,131,0,0q�$
��Wrap=�$��
Categories��$	��Top=��� -'   $ 
cbCategory��$
��Left=�$��252,153,0,0q�$	��Top=�$	��192��$ 0��$��Tempus Sans ITC)��� -(   $	 	btnAddFav��$��+ Add��$
��Left=�$��449,153,0,0q�$	��Top=�$��46��$��22�����	#FFFFD0D0$��Tempus Sans ITC)��� -)   $ imgTree_Copy1��$
��Left=�$	��284��$��
940,0,-5,0q�$	��Top=�$	��269��$0��*/CSharpProject;component/Graphics/tree.jpg���� -*   $ imageBanner_Copy��$
��Left=�$��97��$��	10,10,0,0q�$	��Top=�$	��598��$0��*/CSharpProject;component/Graphics/logo.png���� -+   $	 
btnEditCat��$��Edit...��$
��Left=�$��500,153,0,0q�$	��Top=�$��46��$��22��$ 
0.794,0.53&����	#FFFFD0D0$��Tempus Sans ITC)��� -,   $	 btnDeleteCat��$��Delete Category��$
��Left=�$��676,137,0,0q�$	��Top=�$��75�����	#FFFFD0D0$��Tempus Sans ITC)�$��8(��� --   $ tbEditCatName��$
��Left=�$��22��$��551,153,0,0q�$
 Wrap=�$	��Top=�$	��120��$��Tempus Sans ITC)��� -.   $ labelEditCatName��$��	Edit Name��$
��Left=�$��551,127,0,0q�$	��Top=�$��Tempus Sans ITC)�$��24���� -/   $	 btnEditCatOK��$��OK��$
��Left=�$��676,153,0,0q�$	��Top=�$��75�����	#FFFFD0D0$��Tempus Sans ITC)�$��22���� -0   $ tbAddCat��$
��Left=�$��23��$��449,124,0,0q�$
 Wrap=�$	��Top=�$	��120��$��Tempus Sans ITC)��� -1   $ labelAddCat��$��Category Name?��$
��Left=�$��
449,98,0,0q�$	��Top=�$��Tempus Sans ITC)��� -2   $	 btnAddCatAccept��$��OK��$
��Left=�$��574,124,0,0q�$	��Top=�$��37�����	#FFFFD0D0$��23��$��Tempus Sans ITC)��� -3   $	 btnDL_Local��$��Download��$
��Left=�$��802,495,0,0q�$	��Top=�$��84��$��23��$$ Downloads the selected podcast��$��Tempus Sans ITC)����	#FFFFD0D0$��2q��� -4   $ labelCurrentInterval��$�� ��$
��Left=�$��160,493,0,0q�$	��Top=��� $��Current Update Interval:��$
��Left=�$��
23,493,0,0q�$	��Top=��� -5   $	 btnRemoveFav��$��Remove��$
��Left=�$��176,134,0,0q�$	��Top=�$��39�����	#FFFFD0D0$��Tempus Sans ITC)�$��8(�r� -6   $ mediaElementFavs��$
��Left=�$��16��$��
802,24,0,0q�$	��Top=�$��16��$ Manual=��� -7   $	 btnEditFeed��$��Edit...��$
��Left=�$��131,134,0,0q�$	��Top=�$��39��$��13��$��Tempus Sans ITC)�$��8(����	#FFFFD0D0�� -8   $	 btnPlayWMPFav��$
��Left=�$��928,525,0,0q�$	��Top=�$��42��$��42�����	#FFFFD0D0$��2q�.���� $0��*/CSharpProject;component/Graphics/play.png��$��Uniform=��� -9   $ label1��$"��Play in Windows Media Player��$
��Left=�$��976,535,0,0q�$	��Top=�$ -0.148,-0.092&��� -:   $ tabBtnSettings��$��Settings��.��� -;   $ tabSettings��
������� �� $
��263* ��� $	��30* ��� $
��304* � �� $
��505* ��� $
��509* �.+��� -<   $ labelSettings��$
��Left=�$��	50,55,0,0q�$
��Wrap=�$��Global Settings��$	��Top=�$��Tempus Sans ITC)�$��16(�$
��Bold"��� -=   $ labelFolder��$
��Left=�$��
53,139,0,0q�$
��Wrap=�$��Download Directory��$	��Top=�$��Tempus Sans ITC)��� ->   $ tbDir��$
��Left=�$��23��$��
53,160,0,0q�$ NoWrap=�$	��Top=�$	��414��$��Tempus Sans ITC)�{�.  �� -?   $	 	btnSelect��$��	Select...��$
��Left=�$��
53,188,0,0q�$	��Top=�$��50��$��23��$��Tempus Sans ITC)����	#FFFFD0D0�� $
��Left=�$��53,4,0,0q�$
��Wrap=�$	��Top=�$��Tempus Sans ITC)�$	��183��$��1���� $�Update Interva���� $�l���� -@   $ 
tbInterval��$
��Left=�$��23��$��	86,25,0,0q�$
 Wrap=�$	��Top=�$��29��$��2��$��1���� -A   $ tbEvery��$
��Left=�$��	53,28,0,0q�$
��Wrap=�$��Every��$	��Top=�$��Tempus Sans ITC)�$��2��$��1���� -B   $ 	tbMinutes��$
��Left=�$��
120,28,0,0q�$
��Wrap=�$��Minutes��$	��Top=�$��Tempus Sans ITC)�$��2��$��1���� -C   $ imgTree_Copy2��$
��Left=�$	��284��$��
339,0,-3,0q�$	��Top=�$	��269��$0��*/CSharpProject;component/Graphics/tree.jpg��$��1��$��2���� -D   $	 btnInterval��$	��Set��$
��Left=�$��	53,37,0,0q�$	��Top=�$��39��$��24��$��Tempus Sans ITC)����	#FFFFD0D0$��2��