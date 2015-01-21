var PowerUp =
{
	x: 0,
	y:0, 
	vX: 0,
	vY: 0,
	width: 0,
	height: 0,
	type: 0,
	
	create: function(x, y, vY)	
	{
		this.x = x;
		this.y = y;
		this.vY = vY;
		this.width = 32;
		this.height = 32;
		type = Math.floor(Math.random() * 6) + 1;
	},
	
	update: function()		
	{
		this.y += this.vY;
	},
	
	render: function(context, image)
	{
		context.drawImage(image, this.x, this.y);
	},
	
	powerShotP: function(player)
	{
		player.pierceShotCounter = 100;
	},
	
	powerShotSpread: function(player)
	{
		player.spreadShotCounter = 100;
	},
	
	powerShield: function(player)
	{
		player.shieldCounter = 100;
	},
	
	powerFireRate: function(player)
	{
		player.fireRateUpCounter = 100;
	},
	
	powerSpeed: function(player)
	{
		player.speedUpCounter = 100;
	},
};
