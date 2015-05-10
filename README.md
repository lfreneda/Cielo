Cielo
=====

Integração com o Cielo e-Commerce webservice.

A integração pretende cobrir apenas compras por cartão de créditos sem parcelamento.
Pull requests são bem vindos \o\~

Projeto de exemplo na solução.

Modelo CieloBuyPage
-----

### Criando uma transação

```c#
var order = new Order("12345", 4700.00m, DateTime.Now, "Descrição da ordem");
var paymentMethod = new PaymentMethod(CreditCard.MasterCard, PurchaseType.Credit);
var options = new CreateTransactionOptions(AuthorizationType.AuthorizePassByAuthentication, capture: true);
var createTransactionRequest = new CreateTransactionRequest(order, paymentMethod, options);

CreateTransactionResponse response = _cieloService.CreateTransaction(createTransactionRequest);
```

O objeto **response** (*CreateTransactionResponse*) contém a url para qual o cliente precisa ser redirecionado (ambiente da Cielo, onde ele vai informar os dados do cartão e etc) e o Tid (identificador único daquela transação) que usaremos mais tarde para verificar o status da transação.
		
Modelo LojaBuyPage
-----

### Criando uma transação

```c#
var order = new Order("12345", 4700.00m, DateTime.Now, "Descrição da ordem");
var paymentMethod = new PaymentMethod(CreditCard.MasterCard, PurchaseType.Credit);
var options = new CreateTransactionOptions(AuthorizationType.AuthorizePassByAuthentication, capture: true);
var creditCardData = new CreditCardData("6362970000457013", new CreditCardExpiration(2018, 05), SecurityCodeIndicator.Sent, 123);
var createTransactionRequest = new CreateTransactionRequest(order, paymentMethod, options, creditCardData);

CreateTransactionResponse response = _cieloService.CreateTransaction(createTransactionRequest);
```
	
O objeto **response** (*CreateTransactionResponse*) contém o Tid (identificador único daquela transação) que usaremos mais tarde para verificar o status da transação.
Nota: basicamente o que é diferente da integração CieloBuyPage é que dessa vez fornecemos os dados do cartão de crédito (através do objeto creditCardData)

Verificando status da transação
-----

```c#
var tid = GetTid(); // Recuperar o tid da transação (db,session,whatever)
var checkTransactionRequest = new CheckTransactionRequest(tid);

CheckTransactionResponse response = _cieloService.CheckTransaction(checkTransactionRequest);
```

Cancelando uma transação
-----

```c#
var tid = GetTid(); // Recuperar o tid da transação (db,session,whatever)
var cancelTransactionRequest = new CancelTransactionRequest(tid);

CancelTransactionResponse response = _cieloService.CancelTransaction(cancelTransactionRequest);
```

A verificação da transação é exatamente da mesma forma para os dois modelos, basta ter o Tid.
O objeto **response** (*CheckTransactionResponse* ou *CancelTransactionResponse*) contém o Status da transação que pode conter os seguintes valores:

### 
        Default = -1,
        Created = 0,
        InProgress = 1,
        Authenticated = 2,
        NotAuthenticated = 3,
        Authorized = 4,
        NotAuthorized = 5,
        Success = 6,
        Canceled = 9,
        AuthenticationProgress = 10,
        CancellationProgress = 12
