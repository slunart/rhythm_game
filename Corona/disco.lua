local grau = 0
local direcao = 1
local base = nil
local seletor = nil

local disco = {}
	
	local raio_simbolos = 6
	local raio_disco = 20	
	local x = 0
	local y = 0
	local nomeCores = {"VERMELHO","VERDE","AZUL","AMARELO"}
	local bpm

	disco.selecao_atual = {}
	disco.selecao_atual["disco1"] = "NENHUMA"
	disco.selecao_atual["disco2"] = "NENHUMA"
	disco.selecao_atual["disco3"] = "NENHUMA"
	disco.selecao_atual["disco4"] = "NENHUMA"

	function disco.dispararArma( x1, y1, disco_atual )

		print("Disparando a partir de "..disco_atual)

		local bala = display.newRect( x1, y1 - 50, 4, 8 )
		bala.name = "bala"
		--bala.tipo = tipo
		if disco.selecao_atual[disco_atual] == "CINZA" then
			bala:setFillColor( 1, 0, 0, 1 )
			bala.cor = "CINZA"		 	
		else 
		 	bala:setFillColor( 0.5, 0.5, 0.5, 1 )
			bala.cor = "NENHUMA"		 	
		end

		bala:setStrokeColor( 0, 0, 0 )
		bala.strokeWidth = 1	
		physics.addBody( bala, "dynamic", corpoBala )
		bala.isSensor = true

		-- remove the "isBullet" setting below to see the brick pass through cans without colliding!
		--bala.isBullet = true
		bala.gravityScale = 0
		bala.angularVelocity = 0
		bala:setLinearVelocity( 0, -100 )

		return bala
	end

	function disco.eventoMovimentoSeletor( event )

		grau = grau + 90*direcao

		local radius = grau * (math.pi /180.0);

		seletor.x = base.x + math.cos(radius)*raio_disco
		seletor.y = base.y + math.sin(radius)*raio_disco

		if grau == 360.0 then grau = 0.0 end
		if grau == -360.0 then grau = 0.0 end

		--intersecao()	
	end	

	function disco.criar( x0, y0, d )

		x = x0; y = y0

		direcao = d

		base = display.newCircle( x, y + 10, raio_disco )
		base.name = "base"..x.."-"..y
		base:setFillColor( 0, 0, 0, 0.1 )
		base:setStrokeColor( 0 )
		base.strokeWidth = 2

		local simbolos = {}
		simbolos[1] = display.newCircle( base.x - raio_disco, base.y, raio_simbolos )
		simbolos[2] = display.newCircle( base.x, base.y + raio_disco, raio_simbolos )
		simbolos[3] = display.newCircle( base.x + raio_disco, base.y, raio_simbolos )
		simbolos[4] = display.newCircle( base.x, base.y - raio_disco, raio_simbolos )

		-- {"VERMELHO","VERDE","AZUL","AMARELO"}
		for i=1,4 do
			simbolos[i]:setFillColor( 0.5, 0.5, 0.5, 0.1 )
			simbolos[i].cor = "CINZA"
			simbolos[i]:setStrokeColor( 0 )
			simbolos[i].strokeWidth = 0
			simbolos[i].name=""..i
		end

		seletor = display.newCircle(base.x + raio_disco, base.y, raio_simbolos )
		seletor.name = "seletor"
		seletor:setFillColor( 1, 1, 0, 0.3 )
		seletor:setStrokeColor( 0 )
		seletor.strokeWidth = 2

		-- local function intersecao()
		-- 	for i=1,4 do
		-- 		if seletor.x > simbolos[i].x - raio_simbolos and seletor.x < simbolos[i].x + raio_simbolos then
		-- 			if seletor.y > simbolos[i].y - raio_simbolos and seletor.y < simbolos[i].y + raio_simbolos then
		-- 				disco.selecao_atual[nome] = simbolos[i].cor
		-- 				return
		-- 			end
		-- 		end
		-- 	end	
		-- 	disco.selecao_atual[nome] = "NENHUMA"
		-- end

		local grau = 0.0 -- auxilia para a orbita do seletor sobre o avatar
	
		local grupo = display.newGroup()

		grupo:insert( base )
		for i=1,4 do grupo:insert( simbolos[i] ) end
		grupo:insert( seletor )

		return grupo
	end

return disco