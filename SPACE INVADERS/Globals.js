

//States
var appState;
var SPLASH;
var MAIN_MENU;
var GAME;
var GAME_WON;
var GAME_OVER;
var UPGRADES;
var CREDITS;
//Menu Screens
var splasher = undefined;
var menuScreen = undefined;


//In game state vars
var enemyArray = new Array();
var pBulletsArray = new Array();
var eBulletsArray = new Array();
var enemySpawnX = undefined;
var enemySpawnY = undefined;
var playerSpawnX = undefined;
var playerSpawnY = undefined;
var player = undefined;
var bG1 = undefined;
var bG2 = undefined;
var shotTimer = undefined;
var eShotTimer = undefined;
var numEnemies = undefined;
//var enemyTempVX = undefined; //placeholder for attempt at enemy based speed variance
var pUp = false;

var eImage = new Image();
	eImage.src = "Images/Enemy.png";
	
var pImage = new Image();
	pImage.src = "Images/Player.png";
	
var bImage = new Image();
	bImage.src = "Images/Bullet.png";
	
var bGImage = new Image();
	bGImage.src = "Images/background.png";
//Game HUD	
var gameOverImage = new Image();
	gameOverImage.src = "Images/logo.png";

var splashScreen = new Image();
	splashScreen.src = "Images/logo.png";	
	

