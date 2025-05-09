Cliente ➝ NICK|Laura  
Servidor ➝ ERROR|nickname_duplicado

Cliente ➝ NICK|Laura
Servidor ➝ OK

Servidor ➝ PREGUNTA|¿Capital de Italia?|Roma|París|Madrid|Lisboa
Cliente ➝ RESPUESTA|0 (responde bien)
Servidor ➝ RESULTADO|1|500|Laura:500,Juan:400,Pedro:300

Servidor ➝ PREGUNTA|¿5x5?|10|15|25|30  
Cliente ➝ RESPUESTA|1  (responde mal)
Servidor ➝ RESULTADO|0|0|Juan:900,Laura:500,Pedro:300

Servidor ➝ PREGUNTA|¿2+2?|3|4|5|6
Cliente ➝ RESPUESTA|-1 (no respondió)
Servidor ➝ RESULTADO|0|0|Juan:900,Laura:500,Pedro:300

Servidor ➝ FINPARTIDA|Juan:1500,Laura:1100,Pedro:800
