$(document).ready(function()
{
var canvas = document.getElementById('myCanvas');
var context = canvas.getContext('2d');



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
var div = document.getElementById("textDiv");
var div2 = document.getElementById("textDiv2");
var divWon = document.getElementById("wonDiv");
var nestedDiv = document.getElementById("nestedDiv");

var money = 0;
var bet = 10;
var winnings = 0;

var imageslot1 = new Image();
var imageslot2 = new Image();
var imageslot3 = new Image();
	
function init()
{
	money  = 1000;
	
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
	
	startGame();
}


function update()
{
	//slot 1
	if(slot1curr == 1)
	{
		imageslot1.src = "Images/lilredexpress.png";
	}
	else if(slot1curr == 2)
	{
		imageslot1.src = "Images/38coupe.png";
	}
	else if(slot1curr == 3)
	{
		imageslot1.src = "Images/baracuda.png";
	}
	else if(slot1curr == 4)
	{
		imageslot1.src = "Images/charger.png";
	}
	else if(slot1curr == 5)
	{
		imageslot1.src = "Images/cobra.png";
	}
	else if(slot1curr == 6)
	{
		imageslot1.src = "Images/judgeGTO.png";
	}
	//slot two
	if(slot2curr == 1)
	{
		imageslot2.src = "Images/lilredexpress.png";
	}
	else if(slot2curr == 2)
	{
		imageslot2.src = "Images/38coupe.png";
	}
	else if(slot2curr == 3)
	{
		imageslot2.src = "Images/baracuda.png";
	}
	else if(slot2curr == 4)
	{
		imageslot2.src = "Images/charger.png";
	}
	else if(slot2curr == 5)
	{
		imageslot2.src = "Images/cobra.png";
	}
	else if(slot2curr == 6)
	{
		imageslot2.src = "Images/judgeGTO.png";
	}
	//slot3
	if(slot3curr == 1)
	{
		imageslot3.src = "Images/lilredexpress.png";
	}
	else if(slot3curr == 2)
	{
		imageslot3.src = "Images/38coupe.png";
	}
	else if(slot3curr == 3)
	{
		imageslot3.src = "Images/baracuda.png";
	}
	else if(slot3curr == 4)
	{
		imageslot3.src = "Images/charger.png";
	}
	else if(slot3curr == 5)
	{
		imageslot3.src = "Images/cobra.png";
	}
	else if(slot3curr == 6)
	{
		imageslot3.src = "Images/judgeGTO.png";
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
	}
	else if(slot2spin == true /*&& slot1.spin == false*/)
	{
		slot2spin = false;
	}
	else if(slot3spin == true/* && slot2spin == false && slot3.spin = false*/)
	{
		slot3spin = false;
		gameFinished= true;
		checkForWin();
	}
}
function checkForWin()
{
	if(slot1curr == 1 && slot2curr == 1 && slot3curr == 1)
	{
		winnings = bet * 7;
		div2.textContent = "Jackpot, press space to go again";
					divWon.textContent = "You Won " + winnings;
	}
	else if(slot1curr == 2 && slot2curr == 2 && slot3curr == 2)
	{
		winnings = bet * 4.75;
		div2.textContent = "Almost jackpot, press space to go again";
					divWon.textContent = "You Won " + winnings;
	}
	else if(slot1curr == 3 && slot2curr == 3 && slot3curr == 3)
	{
		winnings = bet * 3.75;
		divWon.textContent = "You Won " + winnings;
					div2.textContent = "Uhh pinapple, press space to go again";
	}
	else if(slot1curr == 4 && slot2curr == 4 && slot3curr == 4)
	{
		winnings = bet * 2.75;
		div2.textContent = "Uhh pinata, press space to go again";
					divWon.textContent = "You Won " + winnings;
	}
	else if(slot1curr == 5 && slot2curr == 5 && slot3curr == 5)
	{
		winnings = bet * 2;
		div2.textContent = "Not the best in fact not even close, press space to go again";
					divWon.textContent = "You Won " + winnings;
	}
	else if(slot1curr == 6 && slot2curr == 6 && slot3curr == 6)
	{
		winnings = bet * 1.75;
		div2.textContent = "All cherries. best part of a fruit salad, press space to go again";
					divWon.textContent = "You Won " + winnings;
	}
	else if(slot1curr == 6 && slot2curr == 6 || slot2curr == 6 && slot3curr == 6)
	{
		winnings = bet * 1.5;
		div2.textContent = "2 cherries, not very good, press space to go again";
					divWon.textContent = "You Won " + winnings;
	}
	else //losing spin
	{
		div2.textContent = "You have lost, try again, press space to go again";
		divWon.textContent = "You Won nothing";
	}
	money += winnings;
}
function startGame()
{
	document.addEventListener("keyup",keyUpHandler, false);
	
	//if(money >= bet)
	//{
		if(gameFinished == true)
		{
			winnings = 0;
			
			money -= bet;
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
			startGame();
		}
	}
}
function drawReels()
{
	context.clearRect(0,0, canvas.width, canvas.height);
	context.drawImage(imageslot1, 0, 0);
	context.drawImage(imageslot2, 400, 0);
	context.drawImage(imageslot3, 800, 0);
}
function gameLoop() 
{
	window.requestAnimationFrame(gameLoop, canvas);
	if(money >= bet)
	{
		div.textContent = "Welcome to the slots. You have $" + money + " currently. It costs $10 to play";
	}
	else
	{
		div.textContent = "You do not have enough money to spin";
	}
	update();
	drawReels();
}
	init();
});