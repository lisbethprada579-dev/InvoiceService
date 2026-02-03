# MEJORA EN PROMPTS 

**PROMPT INICIAL**

"Resume el siguiente texto: [En caso de revocación de la póliza o modificaciones de cualquiera de las condiciones
generales o particulares del seguro por parte de la Aseguradora, Tomador o Asegurado, Seguros Sura se
compromete a dar a viso a BANCO, por escrito y con una antelación no menor a 30 días a la fecha en que surtirá
efecto el hecho. No obstante, lo estipulado en las condiciones generales y particulares de esta póliza, el asegurado
o beneficiario debe dar noticia de la ocurrencia del siniestro a Seguros Sura dentro de los (30) días calendario
siguiente a la fecha en que lo haya conocido. Así mismo, Seguros Sura avisará a BANCO dentro de los diez (10)
días hábiles. En caso de terminación automática por mora del pago de la prima, se le informará por escrito al
beneficiario oneroso con máximo de 30 días de antelación, garantizando la cobertura durante dicho periodo. Por
otro lado, informamos que el seguro referido cuenta con las siguientes características y condiciones:
1. Tienen un valor asegurado de $98.500.000 en caso de fallecimiento.
2. Cubre desde el primer momento, la muerte del asegurado por cualquier causa, incluso en
casos de homicidio, suicidio, terrorismo, embriaguez, secuestro, atraco, presunción de muerte por
desaparecimiento declarado judicialmente, epidemia, pandemia o SIDA siempre y cuando no haya sido
adquirido antes de contratar el seguro.
3. Cubre desde inicio de vigencia incapacidad total y permanente por enfermedad o accidente, también cubre
intento de suicidio y homicidio, terrorismo, embriaguez y atraco; es decir, si el asegurado en cualquiera de los
eventos mencionados pierde de forma permanente el 50% o más de su capacidad laboral, o sufre alguna de las
pérdidas, desmembraciones o inutilizaciones mencionadas en el clausulado del seguro contratado.
4. La vigencia de este seguro comienza a partir de la hora 24:00 del día que aparece en la carátula como día de expedición de la póliza.
5. La edad máxima de permanencia para el amparo de Vida se encuentra estipulada en el clausulado del seguro contratado.
6. Puede ser cedido en caso de una titularización de cartera y dicha cesión debe ser notificada.
7.La forma de pago estipulada para la póliza es anual por COBRO BANCARIO.
8. Las exclusiones generales de esta póliza se encuentran en el clausulado del seguro contratado; las
exclusiones particulares que tenga esta póliza se encuentran en la caratula de la misma.
9. Teniendo en cuenta la circular Externa 028 de 2019 emitida por la Superintendencia Financiera, la entidad
financiera puede ser la pagadora de la prima del seguro de sus consumidores financieros para evitar su
terminación automática]. Devuelve solo un resumen corto y preciso."

**PROMPT PROPUESTO**

Eres un asistente experto en resúmenes legales y técnicos. 
Recibirás un texto y tu tarea es sintetizarlo con máxima precisión, sin agregar, inferir ni omitir información relevante.

### Objetivo
Generar un resumen corto, claro y fiel al contenido, enfocado únicamente en:
- ideas principales
- coberturas
- plazos de aviso
- condiciones relevantes

### Formato de salida (OBLIGATORIO – JSON válido)
{
  "Resumen": "Síntesis breve y objetiva del texto",
  "IdeasPrincipales": ["Idea clave 1", "Idea clave 2"],
  "CoberturasClaves": ["Cobertura 1", "Cobertura 2"],
  "ObligacionesAviso": ["Plazo y responsable 1", "Plazo y responsable 2"],
  "CondicionesImportantes": ["Condición relevante 1", "Condición relevante 2"],
  "Verificacion": "Sí/No",
  "ObservacionVerificacion": ""
}

### Reglas estrictas
1. Usa solo información explícita del texto.
2. No reformules con interpretaciones propias.
3. No agregues ejemplos, opiniones ni explicaciones.
4. No elimines ninguna sección del JSON.
5. Si el texto **no contiene información suficiente** para alguna sección:
   - Marca `"Verificacion": "No"`
   - Explica brevemente qué faltó en `"ObservacionVerificacion"`

### Estilo
- Lenguaje neutro y técnico.
- Frases cortas y precisas.
- Listas concisas (máx. 5 ítems por sección).

### Texto a resumir:
[En caso de revocación de la póliza o modificaciones de cualquiera de las condiciones
generales o particulares del seguro por parte de la Aseguradora, Tomador o Asegurado, Seguros Sura se
compromete a dar a viso a BANCO, por escrito y con una antelación no menor a 30 días a la fecha en que surtirá
efecto el hecho. No obstante, lo estipulado en las condiciones generales y particulares de esta póliza, el asegurado
o beneficiario debe dar noticia de la ocurrencia del siniestro a Seguros Sura dentro de los (30) días calendario
siguiente a la fecha en que lo haya conocido. Así mismo, Seguros Sura avisará a BANCO dentro de los diez (10)
días hábiles. En caso de terminación automática por mora del pago de la prima, se le informará por escrito al
beneficiario oneroso con máximo de 30 días de antelación, garantizando la cobertura durante dicho periodo. Por
otro lado, informamos que el seguro referido cuenta con las siguientes características y condiciones:
1. Tienen un valor asegurado de $98.500.000 en caso de fallecimiento.
2. Cubre desde el primer momento, la muerte del asegurado por cualquier causa, incluso en
casos de homicidio, suicidio, terrorismo, embriaguez, secuestro, atraco, presunción de muerte por
desaparecimiento declarado judicialmente, epidemia, pandemia o SIDA siempre y cuando no haya sido
adquirido antes de contratar el seguro.
3. Cubre desde inicio de vigencia incapacidad total y permanente por enfermedad o accidente, también cubre
intento de suicidio y homicidio, terrorismo, embriaguez y atraco; es decir, si el asegurado en cualquiera de los
eventos mencionados pierde de forma permanente el 50% o más de su capacidad laboral, o sufre alguna de las
pérdidas, desmembraciones o inutilizaciones mencionadas en el clausulado del seguro contratado.
4. La vigencia de este seguro comienza a partir de la hora 24:00 del día que aparece en la carátula como día de expedición de la póliza.
5. La edad máxima de permanencia para el amparo de Vida se encuentra estipulada en el clausulado del seguro contratado.
6. Puede ser cedido en caso de una titularización de cartera y dicha cesión debe ser notificada.
7.La forma de pago estipulada para la póliza es anual por COBRO BANCARIO.
8. Las exclusiones generales de esta póliza se encuentran en el clausulado del seguro contratado; las
exclusiones particulares que tenga esta póliza se encuentran en la caratula de la misma.
9. Teniendo en cuenta la circular Externa 028 de 2019 emitida por la Superintendencia Financiera, la entidad
financiera puede ser la pagadora de la prima del seguro de sus consumidores financieros para evitar su
terminación automática]


## MEJORAS IMPLEMENTADAS EN EL NUEVO PROMPT:
- *Definición de rol experto:* Se especifica que el asistente es experto en resúmenes legales y técnicos para aumentar precisión y fidelidad.
- *Objetivo claramente delimitado:* Se restringe el resumen a ideas, coberturas, plazos y condiciones, evitando contenido accesorio.
- *Formato de salida obligatorio (JSON):* Garantiza consistencia, reutilización y validación automática.
- *Reglas estrictas:* Prohíben inferencias, ejemplos u opiniones, reduciendo desviaciones.
- *Mecanismo de verificación:* Obliga a confirmar que toda la información requerida esté presente.

## EVITA RESPUESTAS IRRELEVANTES

- Elimina ambigüedad sobre qué resumir y cómo hacerlo.
- Limita explícitamente el tipo de información permitida.
- Bloquea interpretaciones y explicaciones adicionales.
- Controla la extensión mediante listas concisas.
- Obliga a declarar cuando falta información en lugar de “inventarla”.


## COMPARACIÓN 

Al ejecutar el prompt inicial se imprime como respuesta: 
**Resumen corto y preciso:**

Seguros Sura notificará por escrito al banco cualquier revocación, modificación o terminación de la póliza con al menos 30 días de anticipación,
y los siniestros deben reportarse dentro de los 30 días siguientes a su conocimiento. El seguro ofrece una cobertura de $98.500.000 por fallecimiento 
y cubre muerte e incapacidad total y permanente por diversas causas desde el inicio de la vigencia. La póliza inicia a las 24:00 del día de expedición, 
tiene límites de edad definidos en el clausulado, puede ser cedida, se paga anualmente por cobro bancario y sus exclusiones están establecidas en el contrato.
Además, la entidad financiera puede pagar la prima para evitar la terminación automática.


Al ejecutar el prompt propuesto se imprime como respuesta:

<img width="1337" height="563" alt="image" src="https://github.com/user-attachments/assets/d0836486-2c3c-49df-879e-8c5eaad75570" />

### Conclusión 

El **prompt inicial** genera un resumen correcto pero narrativo, en un solo bloque de texto, lo que facilita la lectura rápida 
pero dificulta identificar y validar elementos clave como coberturas, plazos y condiciones, además de limitar su reutilización técnica.
En cambio, el **prompt propuesto** produce una salida estructurada y controlada en formato JSON, separando explícitamente 
las ideas principales, coberturas, obligaciones de aviso y condiciones relevantes, lo que reduce el riesgo de omisiones, 
evita interpretaciones, permite verificación explícita y lo hace mucho más adecuado para contextos legales, regulatorios y
de automatización donde la precisión y trazabilidad son críticas.


