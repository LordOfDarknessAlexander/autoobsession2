var lifeObjects = new Array();

var lifeOne = Object.create(LifeObject);
lifeOne.baseInit = lifeOne.init;
lifeOne.baseStart = lifeOne.start;
lifeOne.start = function()
{
	this.baseStart();
	this.yPos = 1;
}

var lifeTwo = Object.create(LifeObject);
lifeTwo.baseInit = lifeTwo.init;
lifeTwo.baseStart = lifeTwo.start;
lifeTwo.start = function()
{
	this.baseStart();
	this.xPos = 30;
}

var lifeThree = Object.create(LifeObject);
lifeThree.baseInit = lifeThree.init;
lifeThree.basStart = lifeThree.start;
lifeThree.start = function()
{
	this.baseStart();
	this.xPos = 60;
}

lifeObjects.push(lifeThree);
lifeObjects.push(lifeTwo);
lifeObjects.push(lifeOne);

function lifeClear (lifeToClear)
{
	lifeObjects[lifeToClear].isDrawn = false;
}

function lifeRemove()
{
	for(var i = 0; i < lifeObjects.length; ++i)
	{
		if(lifeObjects[i].isDrawn)
		{
			setTimeout(function() { lifeClear(i); }, 1000);
			break;
		}
	}
}

function lifeAdd()
{
	for(var i = lifeObjects.length - 1; i >= 0; --i)
	{
		if(!lifeObjects[i].isDrawn)
		{
			lifeObjects[i].isDrawn = true;
		}
	}
}

function resetLives()
{
	for(var i = 0; i < lifeObjects.length; ++i)
	{
		lifeObjects[i].isDrawn = true;
	}
}