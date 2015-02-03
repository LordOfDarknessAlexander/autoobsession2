$(document).ready(function()
{
//var canvas = $('canvas#myCanvas');
//var context = canvas.getContext('2d');

//Reels 
var slot1Canvas = document.getElementById('slot1');//$('canvas#slot1');
var slot1Context = slot1Canvas.getContext('2d');
var slot2Canvas = document.getElementById('slot2');//$('canvas#slot2');
var slot2Context = slot2Canvas.getContext('2d');
var slot3Canvas = document.getElementById('slot3');//$('canvas#slot3');
var slot3Context = slot3Canvas.getContext('2d');

//Buttons
var betButton = document.getElementById('betButton');
var lowerBetButton = document.getElementById('lowerBetButton');
var maxBetButton = document.getElementById('maxBetButton');
var minBetButton = document.getElementById('minBetButton');
var slotStopButton = document.getElementById('slotStop');
var spinButton = document.getElementById('spinButton');

//Play data
var slot1 = [];
var slot2 = [];
var slot3 = [];
var slot1spin = true;
var slot2spin = true;
var slot3spin = true;
var gameFinished = true;
var slot1curr = undefined;
var slot2curr = undefined;
var slot3curr = undefined;
var randSlot1 = 0; 
var randSlot2 = 0;
var randSlot3 = 0;

//Values
var money = 0;
var bet = 10;
var betVal = 10;
var minBet = 10;
var maxBet = 100;
var winnings = 0;

//Images
var imageslot1 = new Image();
var imageslot2 = new Image();
var imageslot3 = new Image();

var CarSheet = new SpriteSheet('images/spritesheet1.png', width = 278, height = 158);

//Sounds
var startSpin = document.getElementById('startSpin');
var reelsSpinning = document.getElementById('reelSpinning');
var noWin = document.getElementById('youLose');
var youWin = document.getElementById('winSound');
var betting = document.getElementById('betSound');

function init()
{
	//initialize bank
	money  = 1000;
	
	//initialize text
	$('div#textDiv').text("Welcome to the slots.");
	$('div#bankValue').text("You have $" + money);
	$('div#betValue').text(bet);
	
	//initialize handlers
	betButton.addEventListener("mousedown", betButtonHandler, false);
	lowerBetButton.addEventListener("mousedown", lowerBetButtonHandler, false);
	maxBetButton.addEventListener("mousedown", maxBetHandler, false);
	minBetButton.addEventListener("mousedown", minBetButtonHandler, false);
	slotStopButton.addEventListener("mousedown", stopButtonHandler, false);
	spinButton.addEventListener("mousedown", spinButtonHandler, false);
	document.addEventListener("keyup",keyUpHandler, false);
	
	//initialize the first slot
	slot1.push(1);
	slot1.push(2);
	slot1.push(2);
	slot1.push(3);
	slot1.push(3);
	slot1.push(3);
	slot1.push(4);
	slot1.push(4);
	slot1.push(4);
	slot1.push(4);
	slot1.push(5);
	slot1.push(5);
	slot1.push(5);
	slot1.push(5);
	slot1.push(6);
	slot1.push(6);
	slot1.push(6);
	slot1.push(6);
	slot1.push(6);
	slot1.push(6);
	//initialize the second slot
	slot2.push(1);
	slot2.push(2);
	slot2.push(2);
	slot2.push(3);
	slot2.push(3);
	slot2.push(3);
	slot2.push(4);
	slot2.push(4);
	slot2.push(4);
	slot2.push(4);
	slot2.push(5);
	slot2.push(5);
	slot2.push(5);
	slot2.push(5);
	slot2.push(6);
	slot2.push(6);
	slot2.push(6);
	slot2.push(6);
	slot2.push(6);
	slot2.push(6);
	//initialize third slot
	slot3.push(1);
	slot3.push(2);
	slot3.push(2);
	slot3.push(3);
	slot3.push(3);
	slot3.push(3);
	slot3.push(4);
	slot3.push(4);
	slot3.push(4);
	slot3.push(4);
	slot3.push(5);
	slot3.push(5);
	slot3.push(5);
	slot3.push(5);
	slot3.push(6);
	slot3.push(6);
	slot3.push(6);
	slot3.push(6);
	slot3.push(6);
	slot3.push(6);
	
	//startGame();
}
function update()
{
	//slot 1
	if(slot1curr == 1)
	{
		imageslot1.src = 'images/ReelImages/lilredexpress.png';
	}
	else if(slot1curr == 2)
	{
		imageslot1.src = 'images/ReelImages/38coupe.png';
	}
	else if(slot1curr == 3)
	{
		imageslot1.src = 'images/ReelImages/baracuda.png';
	}
	else if(slot1curr == 4)
	{
		imageslot1.src = 'images/ReelImages/charger.png';
	}
	else if(slot1curr == 5)
	{
		imageslot1.src = 'images/ReelImages/cobra.png';
	}
	else if(slot1curr == 6)
	{
		imageslot1.src = 'images/ReelImages/judgeGTO.png';
	}
	//slot two
	if(slot2curr == 1)
	{
		imageslot2.src = 'images/ReelImages/lilredexpress.png';
	}
	else if(slot2curr == 2)
	{
		imageslot2.src = 'images/ReelImages/38coupe.png';
	}
	else if(slot2curr == 3)
	{
		imageslot2.src = 'images/ReelImages/baracuda.png';
	}
	else if(slot2curr == 4)
	{
		imageslot2.src = 'images/ReelImages/charger.png';
	}
	else if(slot2curr == 5)
	{
		imageslot2.src = 'images/ReelImages/cobra.png';
	}
	else if(slot2curr == 6)
	{
		imageslot2.src = 'images/ReelImages/judgeGTO.png';
	}
	//slot3
	if(slot3curr == 1)
	{
		imageslot3.src = 'images/ReelImages/lilredexpress.png';
	}
	else if(slot3curr == 2)
	{
		imageslot3.src = 'images/ReelImages/38coupe.png';
	}
	else if(slot3curr == 3)
	{
		imageslot3.src = 'images/ReelImages/baracuda.png';
	}
	else if(slot3curr == 4)
	{
		imageslot3.src = 'images/ReelImages/charger.png';
	}
	else if(slot3curr == 5)
	{
		imageslot3.src = 'images/ReelImages/cobra.png';
	}
	else if(slot3curr == 6)
	{
		imageslot3.src = 'images/ReelImages/judgeGTO.png';
	}
	
	
	if(slot1spin == true)
	{
		randSlot1 = Math.floor(Math.random() * slot1.length);
		slot1curr = slot1[randSlot1];
	}
	if(slot2spin == true)
	{
		randSlot2 = Math.floor(Math.random() * slot2.length);
		slot2curr = slot2[randSlot2];
	}
	if(slot3spin == true)
	{
		randSlot3 = Math.floor(Math.random() * slot3.length);
		slot3curr = slot3[randSlot3];
	}
}
function stop()
{
	if(slot1spin == true)
	{
		slot1spin = false;
		return;
	}
	if(slot2spin == true && slot1spin == false)
	{
		slot2spin = false;
		return;
	}
	if(slot3spin == true && slot2spin == false && slot1spin == false)
	{
		slot3spin = false;
		gameFinished = true;
		reelsSpinning.pause();
		reelSpinning.currTeime == 0.0;
	}
	
	if(gameFinished == true)
	{
		checkForWin();
	}
}
function checkForWin()
{
	if(slot1curr == 1 && slot2curr == 1 && slot3curr == 1)
	{
		winnings = bet * 7;
		$('div#textDiv2').text("Jackpot");
					$('div#wonDiv').text("You Won " + winnings);
					//Play sound
					playWinSound();
	}
	else if(slot1curr == 2 && slot2curr == 2 && slot3curr == 2)
	{
		winnings = bet * 4.75;
		$('div#textDiv2').text("Almost jackpot");
					$('div#wonDiv').text("You Won " + winnings);
					//Play sound
					playWinSound();

	}
	else if(slot1curr == 3 && slot2curr == 3 && slot3curr == 3)
	{
		winnings = bet * 3.75;
		$('div#textDiv2').text("Uhh pinapple");
					$('div#wonDiv').text("You Won " + winnings);
					//Play sound
					playWinSound();

	}
	else if(slot1curr == 4 && slot2curr == 4 && slot3curr == 4)
	{
		winnings = bet * 2.75;
		$('div#textDiv2').text("Uhh pinata");
					$('div#wonDiv').text("You Won " + winnings);
					//Play sound
					playWinSound();

	}
	else if(slot1curr == 5 && slot2curr == 5 && slot3curr == 5)
	{
		winnings = bet * 2;
		$('div#textDiv2').text("Not the best in fact not even close");
					$('div#wonDiv').text("You Won " + winnings);
					//Play sound
					playWinSound();

	}
	else if(slot1curr == 6 && slot2curr == 6 && slot3curr == 6)
	{
		winnings = bet * 1.75;
		$('div#textDiv2').text("All cherries. best part of a fruit salad");
					$('div#wonDiv').text("You Won " + winnings);
					//Play sound
					playWinSound();

	}
	else if(slot1curr == 6 && slot2curr == 6 || slot2curr == 6 && slot3curr == 6)
	{
		winnings = bet * 1.5;
		$('div#textDiv2').text("2 cherries, not very good");
					$('div#wonDiv').text("You Won " + winnings);
					//Set volume and play sound
					//youWin.currTime = 0.0;
					//youWin.volume = 0.5;
					//youWin.play();
					playWinSound();

	}
	else //losing spin
	{
		$('div#textDiv2').text("You have lost");
					$('div#wonDiv').text("You Won nothing");
					//set volume and play sound
					noWin.currTime = 0.0;
					//noWin.volume = 0.1;
					//noWin.play();
					playLossSound();
	}
	money += winnings;
		$('div#bankValue').text("You have $" + money);

}
function startGame()
{
	
	//if(money >= bet)
	//{
		if(gameFinished == true)
		{
			winnings = 0;
			
			money -= bet;
				$('div#bankValue').text("You have $" + money);
			
			slot1spin = true;
			slot2spin = true;
			slot3spin = true;
			gameFinished = false;
		}
		else
		{
			stop();
		}
	//}
	gameLoop();
}
function keyUpHandler(event)
{
	var keyPressed = event.keyCode;
	
	if (keyPressed == 32)
	{
		if(money >= bet)
		{
			playReelSpin();

			startGame();
		}
	}
}
function spinButtonHandler(event)
{
	//startGame();
	if(money >= bet)
	{
		if(gameFinished == true)
		{
			winnings = 0;
			
			playReelSpin();
			
			money -= bet;
				$('div#bankValue').text("You have $" + money);
			slot1spin = true;
			slot2spin = true;
			slot3spin = true;
			gameFinished = false;
		}
		else
		{
			return;
		}
	}
	gameLoop();

}
function betButtonHandler(event)
{
	if(bet < maxBet)
	{
		bet += betVal;
		$('div#betValue').text(bet);
		playBetSound();		
	}
}
function lowerBetButtonHandler(event)
{
	if(gameFinished == true)
	{
		if(bet > minBet)
		{
			bet -= betVal;
			$('div#betValue').text(bet);	
		}
	}
	else
	{
		return;
	}
}
function maxBetHandler(event)
{
	if(gameFinished == true)
	{
		bet = maxBet;
		$('div#betValue').text(bet);
		playBetSound();
	}
	else
	{
		return;
	}
}
function minBetButtonHandler(event)
{
	if(gameFinished == true)
	{
		bet = minBet;
		$('div#betValue').text(bet);
	}
	else
	{
		return;
	}
}

function stopButtonHandler(event)
{
	if(gameFinished == false)
	{
		stop();
	}
	else
	{
		return;
	}
}
function spinReels()
{
	slot1Context.drawImage(imageslot1, 0, 0);
	slot2Context.drawImage(imageslot2, 0, 0);
	slot3Context.drawImage(imageslot3, 0, 0);
}
function gameLoop() 
{
	window.requestAnimationFrame(gameLoop, $('canvas#myCanvas'));

	update();
	spinReels();
}
function playWinSound()
{
	//stop other sounds
	startSpin.pause();
	reelSpinning.pause();

	//Set volume and play sound
	youWin.currTime = 0.0;
	youWin.volume = 0.5;
	youWin.play();
}
function playLossSound()
{
	//stop othe sounds
	startSpin.pause();
	reelSpinning.pause();
	
	//set volume and play sound
	noWin.currTime = 0.0;
	noWin.volume = 0.5;
	noWin.play();
}
function playReelSpin()
{
	//stop all other sound
	betting.pause();
	betting.currTime == 0.0;
	noWin.pause();
	noWin.currTime == 0.0;
	youWin.pause();
	youWin.currTime = 0.0;

	//set volume and play sound
	startSpin.currTime = 0.0;
	startSpin.volume = 0.5;
	startSpin.play();
	
	reelSpinning.currTime == 0.0;
	reelsSpinning.volume = 0.5;
	reelsSpinning.play();
	reelSpinning.loop = true;
}
function playBetSound()
{
	//set volume and play sound
	betting.currTime = 0.0;
	betting.volume = 1.0;
	betting.play();
}
	init();
});