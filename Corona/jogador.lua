local jogador = {}

local deg = 0.0 -- auxilia para a orbita do seletor sobre o avatar

local balas = {}
local corpoBala = { density=0.8, friction=1.0, bounce=.7, radius=8 }
local n = 0
local tempo_vida_bala = 1000
jogador.avatar = nil
jogador.base = nil
jogador.simbolos = {}
jogador.simbolosLabel = {}
jogador.seletor = nil
jogador.velocidadeSeletor = 100
jogador.centro_x = 0
jogador.centro_y = 0
jogador.raio_simbolos = 8
jogador.intersecao = 0

local function intersecao()

	if jogador.seletor.x > jogador.simbolos[1].x - jogador.raio_simbolos and jogador.seletor.x < jogador.simbolos[1].x + jogador.raio_simbolos then
		if jogador.seletor.y > jogador.simbolos[1].y - jogador.raio_simbolos and jogador.seletor.y < jogador.simbolos[1].y + jogador.raio_simbolos then
			jogador.intersecao = "Y"
			return
		end
	end
	if jogador.seletor.x > jogador.simbolos[2].x - jogador.raio_simbolos and jogador.seletor.x < jogador.simbolos[2].x + jogador.raio_simbolos then
		if jogador.seletor.y > jogador.simbolos[2].y - jogador.raio_simbolos and jogador.seletor.y < jogador.simbolos[2].y + jogador.raio_simbolos then
			jogador.intersecao = "ABAIXO"
			return
		end
	end	
	if jogador.seletor.x > jogador.simbolos[3].x - jogador.raio_simbolos and jogador.seletor.x < jogador.simbolos[3].x + jogador.raio_simbolos then
		if jogador.seletor.y > jogador.simbolos[3].y - jogador.raio_simbolos and jogador.seletor.y < jogador.simbolos[3].y + jogador.raio_simbolos then
			jogador.intersecao = "X"
			return
		end
	end	
	if jogador.seletor.x > jogador.simbolos[4].x - jogador.raio_simbolos and jogador.seletor.x < jogador.simbolos[4].x + jogador.raio_simbolos then
		if jogador.seletor.y > jogador.simbolos[4].y - jogador.raio_simbolos and jogador.seletor.y < jogador.simbolos[4].y + jogador.raio_simbolos then
			jogador.intersecao = "ACIMA"
			return
		end
	end		
	jogador.intersecao = 0	
end

local function eventoMovimentoSeletor( event )

	deg = deg + 10;

	local radius = deg * (math.pi /180.0);

	jogador.seletor.x = jogador.centro_x + math.cos(radius)*32
	jogador.seletor.y = jogador.centro_y + math.sin(radius)*32

	intersecao()	
	--print(jogador.intersecao)
end	

jogador.dispararArma = function( x1, y1, tipo )
	n = n + 1

	dx = x2
	dy = y2

	balas[n] = display.newRect( jogador.avatar.x + x1, jogador.avatar.y + y1, 8, 4 )
	balas[n].name = "bala"
	balas[n].tipo = tipo
	balas[n]:setFillColor( 0, 0, 0, 1 )
	balas[n]:setStrokeColor( 0, 0, 0 )
	balas[n].strokeWidth = 1	
	physics.addBody( balas[n], "dynamic", corpoBala )
	balas[n].isSensor = false

	-- remove the "isBullet" setting below to see the brick pass through cans without colliding!
	balas[n].isBullet = true
	balas[n].gravityScale = 0
	balas[n].angularVelocity = 0
	balas[n]:setLinearVelocity( 100, 0 )
	--balas[n]:applyForce( dx * forca, dy * forca, balas[n].x, balas[n].y )

	return balas[n]
end


jogador.createAvatar = function()

	-- personagem
	jogador.avatar = display.newCircle( display.contentCenterX - 160, display.contentCenterY, 16 )
	jogador.avatar:setFillColor( 0.3, 0.3, 0.3 )
	jogador.avatar.name = "jogador"
	physics.addBody( jogador.avatar, "dynamic", { density=2.0, friction=0.5, bounce=0.3 } )								-- 1
	jogador.avatar.isSensor = true

	return avatar	
end

jogador.criarOrbita = function( raio )

	jogador.centro_x = display.contentCenterX - 160
	jogador.centro_y = display.contentCenterY

	local avatar = jogador.createAvatar()

	local base_raio = 32
	jogador.base = display.newCircle( jogador.centro_x, jogador.centro_y, base_raio )
	jogador.base.name = "base"
	jogador.base:setFillColor( 1, 1, 1, 0 )
	jogador.base:setStrokeColor( 0, 0, 0 )
	jogador.base.strokeWidth = 2

	jogador.simbolos[1] = display.newCircle( jogador.centro_x - 2*raio, jogador.centro_y, jogador.raio_simbolos )
	jogador.simbolos[1].name="Y"
	jogador.simbolos[1]:setFillColor( 0, 0, 1, 1 )
	jogador.simbolos[2] = display.newCircle( jogador.centro_x, jogador.centro_y + 2*raio, jogador.raio_simbolos )
	jogador.simbolos[2].name="▼"
	jogador.simbolos[2]:setFillColor( 1, 1, 0, 1 )
	jogador.simbolos[3] = display.newCircle( jogador.centro_x + 2*raio, jogador.centro_y, jogador.raio_simbolos )
	jogador.simbolos[3].name="X"
	jogador.simbolos[3]:setFillColor( 1, 0, 0, 1 )
	jogador.simbolos[4] = display.newCircle( jogador.centro_x, jogador.centro_y - 2*raio, jogador.raio_simbolos )
	jogador.simbolos[4].name="▲"
	jogador.simbolos[4]:setFillColor( 1, 1, 0, 1 )

	for i=1,4 do
		--jogador.simbolos[i]:setFillColor( 0, 0, 0, 1 )
		jogador.simbolos[i]:setStrokeColor( 0, 0, 0 )
		jogador.simbolos[i].strokeWidth = 0
	end

	jogador.seletor = display.newCircle( jogador.centro_x + base_raio, jogador.centro_y, 8 )
	jogador.seletor.name = "seletor"
	jogador.seletor:setFillColor( 1, 1, 0, 0.3 )
	jogador.seletor:setStrokeColor( 0, 0, 0 )
	jogador.seletor.strokeWidth = 2
	timer.performWithDelay( jogador.velocidadeSeletor, eventoMovimentoSeletor, 0 )

	local grupo = display.newGroup()

	grupo:insert( jogador.avatar ) 	
	grupo:insert( jogador.base ) 				-- 6
	grupo:insert( jogador.simbolos[1] ) 		-- 7
	grupo:insert( jogador.simbolos[2] ) 		-- 8
	grupo:insert( jogador.simbolos[3] ) 		-- 9
	grupo:insert( jogador.simbolos[4] )  		-- 10
	grupo:insert( jogador.seletor ) 			-- 15	

	return grupo
end

return jogador