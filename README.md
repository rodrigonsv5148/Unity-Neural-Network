Rodrigo Nunes Santiago Veiga

OBS: Caso tenha algum problema ao abrir ou executar a versão do Git, favor priorizar a versão enviada por Zip no classroom.

6.6.: Prática em Laboratório UNITY - Redes Neurais Artificiais

a) Como a Rede Neural seleciona 'a cor mais fácil de ler'?

A rede neural coloca dois quadrados com a mesma na tela, um com o texto na cor branca e outro na cor preta. Após isso, é a aplicação espera o usuário selecionar um desses quadrados. A ideia é que o usuário selecione o quadrado com a cor de texto mais legível. Após repetir o processo 10 vezes, o código começa a dizer (baseado no que aprendeu) qual cor de texto está mais fácil de ler naquela cor de quadrado.
b) Como funciona o passo prévio de treinamento e passo posterior de uso do modelo treinado?

O passo prévio de treinamento funciona adquirindo as informações com base no usuário, para treinar, o algoritmo pega a cor do quadrado, a seleção do usuário baseado no quadrado I1 (Se o jogador selecionar o quadrado I1(O da direita), o valor da seleção será 1, caso contrário, esse valor será 0). O algoritmo pega esses valores e adiciona em uma lista de conjunto de dados até que a lista tenha 10 elementos, quando completa essa quantidade, o método Train() é chamado, sendo ele responsável por treinar a rede neural baseado no conjunto de dados e no erro mínimo setado e setar a variável booleana trained como True. 

Após o processo acima ser concluido, o método que coloca as novas cores vai ativar uma estrutura condicional baseada na variável trained, onde esse método vai testar internamente se uma variável chamada de "d" é maior ou menor que 0.5, caso seja maior, o ponteiro 2 é ativado, caso não, o ponteiro 1 é ativado, assim identificando qual dos quadrados a rede neural escolheu como resposta. Para fazer isso, a variável "d" chama o método tryValues que pega o valor da cor e pede para a rede neural computa-lo através do .Compute() e retorna o resultado ao usuário.

c) Faça uma variação desde código para um outro exemplo utilizando o UNITY 
Agora o código dispõe de 3 quadrados envés de 2, embaixo de cada quadrado tem a cor a qual ele representa, Red, Green, Blue. A aplicação agora esperará o usuário pressionar um dos 3 quadrados, o que o usuário escolher significará que essa cor (para o usuário) está mais próxima do nome que está escrito no quadrado. Logo ao escolher o primeiro quadrado, significa que para aquele usuário a cor dos quadrados está mais próxima de Red, o segundo significa que está mais próximo de Green e o terceiro de Blue.
