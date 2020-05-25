# Especificação

A cafeteira Mark IV Special produz até 12 xícaras de café por vez. O usuário
coloca um filtro no porta-filtro, enche o filtro com grãos de café e desliza
o porta-filtro para seu receptáculo. Então, o usuário despeja até 12 xícaras
de água no respectivo receptáculo e pressiona o botão Brew (Preparar).
A água é aquecida até ferver. A pressão do vapor força a água a borrifar nos
grãos de café e o café goteja na jarra, passando pelo filtro. A jarra é
mantida aquecida por períodos prolongados por meio de uma chapa de aquecimento,
a qual só é ligada se houver café na jarra. Se a jarra é retirada da chapa de
aquecimento enquanto a água está sendo borrifada nos grãos, o fluxo de água
é interrompido para que o café filtrado não seja derramado na chapa. Os
seguintes itens de hardware precisam ser monitorados ou controlados:

- A resistência do boiler. Ela pode ser ligada ou desligada.
- A resistência da chapa de aquecimento. Ela pode ser ligada ou desligada.
- O sensor da chapa de aquecimento. Ele tem três estados: warmerEmpty, potEmpty,
  potNotEmpty (aquecedor vazio, jarra vazia e jarra não vazia, respectivamente).
- Um sensor para o boiler, o qual determina se ele contém água. Ele tem dois
  estados: boilerEmpty ou boilerNotEmpty (boiler vazio, boiler não vazio).
- O botão Brew. Esse botão momentâneo inicia o ciclo de preparação. Ele tem um
  indicador que acende quando o ciclo de preparação termina e o café está pronto.
- Uma válvula de alívio de pressão que se abre para reduzir a pressão no boiler.
  A queda de pressão interrompe o fluxo de água no filtro. A válvula pode ser
  aberta ou fechada.

O hardware da Mark IV foi projetado e atualmente está em desenvolvimento.
Os engenheiros de hardware forneceram uma API de baixo nível para utilizarmos,
de modo que não precisamos escrever nenhum código de driver de E/S trabalhoso.
