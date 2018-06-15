local physics = require( "physics" )
physics.start()
physics.setGravity( 0, 1 )

local oponente = require("oponente")

local tamanho = 24
local tempo = 1000
local posicaoH = 64
local offset_x = 32 

local sequencia = {}

	sequencia.representacao = {}
	sequencia.representacao[1] = {
	--		1	2	3	4	5	6	7	8	9	10	11	12
		{	"R",0,	0,	0,	0,	0,	"R",0,	0,	0,	0,	0,	1,	0,	"Y",0,	0,	0,	"B",0,	0,	"R",0,	0	}, -- trilha 1
		{	0,	0,	0,	"B",0,	0,	0,	0,	"Y",0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0	}, -- trilha 2
		{	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	"R",0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	"R"	}, -- trilha 3
		{	0,	0,	0,	0,	0,	"G",0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	"G",0	}  -- trilha 4
	}

	local function criarNPC( m, n )

		local notas = {}
		local qtde = 0

		for trilha = 1, 4 do

			if sequencia.representacao[ m ][ trilha ][ n ] ~= 0 then
				qtde = qtde + 1

				local notas = {}

				local x = 0
				local y = display.contentCenterY - 200

				if trilha == 1 then
					x = posicaoH*0.5 + offset_x
				elseif trilha == 2 then
					x = posicaoH*1.5 + offset_x
				elseif trilha == 3 then
					x = posicaoH*2.5 + offset_x
				elseif trilha == 4 then
					x = posicaoH*3.5 + offset_x
				end

				--notas[ qtde ] = display.newRect( x, y, 58, 4 )

				if sequencia.representacao[ m ][ trilha ][ n ] == "R" then
					notas[ qtde ] = oponente.criar("VERMELHO")					
					--notas[ qtde ]:setFillColor( 1, 0, 0, 1 )
					notas[ qtde ].cor = "VERMELHO"
				elseif sequencia.representacao[ m ][ trilha ][ n ]  == "G" then
					notas[ qtde ] = oponente.criar("VERDE")						
					--notas[ qtde ]:setFillColor( 0, 1, 0, 1 )
					notas[ qtde ].cor = "VERDE"					
				elseif sequencia.representacao[ m ][ trilha ][ n ]  == "B" then
					notas[ qtde ] = oponente.criar("AZUL")						
					--notas[ qtde ]:setFillColor( 0, 0, 1, 1 )
					notas[ qtde ].cor = "AZUL"					
				else
					notas[ qtde ] = oponente.criar("AMARELO")	
					--notas[ qtde ]:setFillColor( 1, 1, 0, 1 )
					notas[ qtde ].cor = "AMARELO"					
				end
				notas[ qtde ].x = x
				notas[ qtde ].y = y
				notas[ qtde ].name = "nota"
				notas[ qtde ].trilha = trilha_atual
				notas[ qtde ].tempo = n
				notas[ qtde ]:setStrokeColor( 0, 0, 0 )
				notas[ qtde ].strokeWidth = 0
				physics.addBody( notas[ qtde ], { density=1.0 } )		
				notas[ qtde ].isSensor = true		
				notas[ qtde ].gravityScale = 0
				notas[ qtde ]:setLinearVelocity( 0, 70 )

				notas[ qtde ]:play()
			else
				notas[ qtde ] = nil
			end
		end

		return notas
	end

	function sequencia.criar( m )

		local todas_notas = {}

		local t = 1
		timer.performWithDelay( tempo, function()
			--todas_notas = criarNotas( m, t )	
			todas_notas = criarNPC( m, t )	
			t = t + 1		
		end, tamanho )

		return todas_notas
	end

return sequencia