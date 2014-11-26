$(document).ready(function()
{
	var canvas = document.getElementById('myCanvas');
	var context = canvas.getContext('2d');
	
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
		
	function GameStart()
	{	
		enemySpawnX = 0;
		enemySpawnY = 0;
		playerSpawnX = 500;
		playerSpawnY = 500;
		numEnemies = 5;
		//enemyTempVX = 10; // for adjusting enemy speed
		shotTimer = 0;
		eShotTimer = 0;
		player = Object.create(Player);
		player.create(playerSpawnX, playerSpawnY, 0, 0, pImage);
		player.isControlable = true;
		
		bG1 = Object.create(Background);
			bG1.create(0, 0, 1);
		bG2 = Object.create(Background);
			bG2.create(0, -768, 1);
		for(var i = 0; i < numEnemies; i++)
		{
			spawnEnemy();
			enemySpawnX += 45;
		}
		enemySpawnX = 0;
			document.addEventListener("keydown",keyDownHandler, false);	
			document.addEventListener("keyup",keyUpHandler, false);	
		gameLoop();
	}
	
	function gameLoop() 
	{
		window.requestAnimationFrame(gameLoop, canvas);
		update();
	}
	
	function update() 
	{
		context.clearRect(0, 0, myCanvas.width, myCanvas.height);
		bG1.update();
		bG1.render(context, bGImage);
		bG2.update();
		bG2.render(context, bGImage);
		if(eShotTimer > 0)
		{
			eShotTimer--;
		}
		if(shotTimer > 0)
		{
			shotTimer--;
		}
		if(enemyArray.length > 0)
		{
			eShoot();
		}
		if(bG1.y >= 766)
		{
			bG1.y = bG2.y + -766;
		}
		if(bG2.y >= 766)
		{
			bG2.y = bG1.y + -766;
		}
		for(var i = 0; i < enemyArray.length; i++)
		{	
			if(enemyArray[i].x + enemyArray[i].width > 768)
			{
				enemyArray[i].vX *= -1;
			}
			if(enemyArray[i].x < 0)
			{
				enemyArray[i].vX *= -1;
			}
			if(enemyArray[i].y < 0)
			{
				enemyArray[i].vY *= -1;
			}
			if(enemyArray[i].y + enemyArray[i].height >= 300)
			{
				enemyArray[i].vY *= -1;
			}
			//enemyArray[i].vX = enemyTempVX / enemyArray.length; //adjusts speed based on number of enemies left
			enemyArray[i].update();
			enemyArray[i].render(context, eImage);
		}
		player.update();
		player.render(context, pImage);
		for(var i = 0; i < pBulletsArray.length; i++)
		{
			pBulletsArray[i].update();
			pBulletsArray[i].render(context, bImage);
		}
		for(var i = 0; i < eBulletsArray.length; i++)
		{
			eBulletsArray[i].update();
			eBulletsArray[i].render(context, bImage);
		}
		for(var i = 0; i < pBulletsArray.length; i++)
		{
			if(pBulletsArray[i].x + pBulletsArray[i].width < 0)
			{
				pBulletsArray.splice(i, 1);
			}
		}
		if(pBulletsArray.length != 0 && enemyArray != 0)
		{
			eCollision(pBulletsArray, enemyArray);
		}
		
		if(eBulletsArray.length != 0)
		{
			pCollision(eBulletsArray, player);
		}
		if(enemyArray.length <= 0)
		{
			if(numEnemies < 17)
			{
				numEnemies += 1;
			}
			for(var i = 0; i < numEnemies; i++)
			{
				spawnEnemy();
				enemySpawnX += 45;
			}
			enemySpawnX = 0;
		}
		
	}
	function keyUpHandler(event)
	{
		var keyPressed = event.keyCode;
		if (keyPressed == 38 || keyPressed == 40)
		{	
			player.vY = 0;
		}
		else if (keyPressed == 39 || keyPressed == 37)
		{	
		 	player.vX = 0;
		}
	}
	function keyDownHandler(event)
	{
		var keyPressed = event.keyCode;
		if(player.isControlable)
		{
			
			if (keyPressed == 38)
			{	
				player.vY = -4;
			}
			else if (keyPressed == 40)
			{	
				player.vY = 4;	
			}
			else if (keyPressed == 39)
			{	
				player.vX = 4;
			}
			else if (keyPressed == 37)
			{	
				player.vX = -4;
			}
			if(keyPressed == 32)
			{
				pShoot();
			}
		}
	}
	function spawnEnemy()
	{
		var enemy = Object.create(Enemy);
		enemy.create(enemySpawnX, enemySpawnY, 2, 1);
		enemyArray.push(enemy)
		enemySpawnX + 5;
	}
	function pShoot()
	{
		if(shotTimer <= 0)
		{
		var bullet = Object.create(Projectile);
		var bullet2 = Object.create(Projectile);
		bullet.create(player.x , player.y, -3);
		bullet2.create(player.x + 50 , player.y, -3);
		pBulletsArray.push(bullet);
		pBulletsArray.push(bullet2);
		shotTimer = 50;
		}
	}
	function eShoot()
	{
		if(eShotTimer <= 0)
		{
		var ran =  Math.floor(Math.random() * enemyArray.length);
		var bullet = Object.create(Projectile);
		bullet.create(enemyArray[ran].x , enemyArray[ran].y, 3);
		eBulletsArray.push(bullet);
		eShotTimer = 40;
		}
	}
	function pCollision(bArray, player)
	{
		for(var i = 0; i < bArray.length; i++)
		{
			if((bArray[i].x >= player.x || bArray[i].x + bArray[i].width >= player.x) && (bArray[i].x <= player.x + player.wigth || bArray[i].x + bArray[i].width <= player.x + player.width))
			{
				if((bArray[i].y >= player.y || bArray[i].y + bArray[i].height >= player.y) && (bArray[i].y <= player.y + player.height || bArray[i].y + bArray[i].height <= player.y + player.height))
				{
					bArray.splice(i, 1);
					gameOver();
				}
			}
		}
	}
	function gameOver()
	{
		pImage.src = "";
		player.isControlable = false;
	}
	function eCollision(bArray, eArray)
	{
		for(var i = 0; i < bArray.length; i++)
		{
			for(var j = 0; j < eArray.length; j++)
			{
				if((bArray[i].x >= eArray[j].x || bArray[i].x + bArray[i].width >= eArray[j].x) && (bArray[i].x <= eArray[j].x + eArray[j].wigth || bArray[i].x + bArray[i].width <= eArray[j].x + eArray[j].width))
				{
					if((bArray[i].y >= eArray[j].y || bArray[i].y + bArray[i].height >= eArray[j].y) && (bArray[i].y <= eArray[j].y + eArray[j].height || bArray[i].y + bArray[i].height <= eArray[j].y + eArray[j].height))
					{
						bArray.splice(i, 1);
						eArray.splice(j, 1);
					}
				}
			}
		}
	}
	GameStart();
});