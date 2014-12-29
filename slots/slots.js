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
var gamefinished = true;
var slot1curr = undefined;
var slot2curr = undefined;
var slot3curr = undefined;
var randSlot1 = 0; 
var randSlot2 = 0;
var randSlot3 = 0;
var div = document.getElementById("textDiv");
var nestedDiv = document.getElementById("nextedDiv");

var money = 0;
var bet = 0;
var imageslot1 = new Image();
var imageslot2 = new Image();
var imageslot3 = new Image();
	
function init()
{
	money  = 100;
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
}


function update()
{
	//slot 1
	if(slot1curr == 1)
	{
		imageslot1.src = "Images/000.png";
	}
	else if(slot1curr == 2)
	{
		imageslot1.src = "Images/001.png";
	}
	else if(slot1curr == 3)
	{
		imageslot1.src = "Images/002.png";
	}
	else if(slot1curr == 4)
	{
		imageslot1.src = "Images/003.png";
	}
	else if(slot1curr == 5)
	{
		imageslot1.src = "Images/004.png";
	}
	else if(slot1curr == 6)
	{
		imageslot1.src = "Images/005.png";
	}
	//slot two
	if(slot2curr == 1)
	{
		imageslot2.src = "Images/000.png";
	}
	else if(slot2curr == 2)
	{
		imageslot2.src = "Images/001.png";
	}
	else if(slot2curr == 3)
	{
		imageslot2.src = "Images/002.png";
	}
	else if(slot2curr == 4)
	{
		imageslot2.src = "Images/003.png";
	}
	else if(slot2curr == 5)
	{
		imageslot2.src = "Images/004.png";
	}
	else if(slot2curr == 6)
	{
		imageslot2.src = "Images/005.png";
	}
	//slot3
	if(slot3curr == 1)
	{
		imageslot3.src = "Images/000.png";
	}
	else if(slot3curr == 2)
	{
		imageslot3.src = "Images/001.png";
	}
	else if(slot3curr == 3)
	{
		imageslot3.src = "Images/002.png";
	}
	else if(slot3curr == 4)
	{
		imageslot3.src = "Images/003.png";
	}
	else if(slot3curr == 5)
	{
		imageslot3.src = "Images/004.png";
	}
	else if(slot3curr == 6)
	{
		imageslot3.src = "Images/005.png";
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
	if(gamefinished == true)
	{
		if(slot1curr == 1 && slot2curr == 1 && slot3curr == 1)
		{
			console.log("jackpot, press space to go again");
		}
		else if(slot1curr == 2 && slot2curr == 2 && slot3curr == 2)
		{
			console.log("almost jackpot, press space to go again");
		}
		else if(slot1curr == 3 && slot2curr == 3 && slot3curr == 3)
		{
			console.log("uhh pinapple, press space to go again");
		}
		else if(slot1curr == 4 && slot2curr == 4 && slot3curr == 4)
		{
			console.log("uhh pinata, press space to go again");
		}
		else if(slot1curr == 5 && slot2curr == 5 && slot3curr == 5)
		{
			console.log("not the best in fact not even close, press space to go again");
		}
		else if(slot1curr == 6 && slot2curr == 6 && slot3curr == 6)
		{
			console.log("all cherries. best part of a fruit salad, press space to go again");
		}
		else if(slot1curr == 6 && slot2curr == 6 || slot2curr == 6 && slot3curr == 6)
		{
			console.log("2 cherries, not very good, press space to go again");
		}
		else //losing spin
		{
			console.log("you have lost, try again, press space to go again");
		}
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
		gamefinished = true;
	}
}
function startGame()
{
	document.addEventListener("keyup",keyUpHandler, false);	
	init();
	gameLoop();
	
	//document.addEventListener("keydown",keyDownHandler, false);	
	
}
function keyUpHandler(event)
{
	var keyPressed = event.keyCode;
	if(money >= 10)
	{
		if (keyPressed == 32)
		{	
			if(gamefinished == true)
			{
				money -= 10;
				slot1spin = true;
				slot2spin = true;
				slot3spin = true;
				gamefinished = false;
			}
			else
			{
				stop();
			}
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
	if(money >= 10)
	{
		div.textContent = "welcome to the slots. You have $" + money + " currently. it costs $10 to play";
	}
	else
	{
		div.textContent = "You do not have enough money to spin";
	}
	update();
	drawReels();
	console.log("slot1: " + slot1curr + " slot2: " + slot2curr + " slot3: " + slot3curr);
}
	startGame();
});