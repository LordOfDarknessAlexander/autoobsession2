var lifeOne = Object.create(LifeObjectClass);
lifeOne.init(10, 1);

var lifeTwo = Object.create(LifeObjectClass);
lifeTwo.init(30, 1);

var lifeThree = Object.create(LifeObjectClass);
lifeThree.init(50, 1);

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