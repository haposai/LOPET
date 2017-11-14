<%@ Page Title="" Language="C#" MasterPageFile="~/Lopet/GG.Master" AutoEventWireup="true" CodeBehind="RealizarPago.aspx.cs" Inherits="Lopet.Lopet.RealizarPago" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="form-group row">
         <h3>Realizar Pago</h3>
         <br />
      <div class="col-xs-3">
        <label for="ex2">Importe (S/.):</label>
        <asp:TextBox  class="form-control" ID="txt_monto" Visible="true" runat="server" Text="13.00"></asp:TextBox>
       </div>
       </div>
    <div id="paypal-button"></div>

<script src="https://www.paypalobjects.com/api/checkout.js"></script>

<script>
    paypal.Button.render({
        
        env: 'production', // Or 'sandbox'

        client: {
            sandbox:'access_token$sandbox$vdf9jgt2qz89fbhb$209ee35926cf587eee85b5bad644d739',
            //sandbox: 'AVN-hI-i7rdne8Da9b76cl1Tm9y8fLO3djYx1t9NHHZLsXHnpsciw5zfnXj9Rxvrix_cqyBEVUiUP7X3',
            production: 'AT8BJLHgN8pZYTUr64gUIEWG7b7_eUseFAWDPz2bH6ahwt3WRo9l7yQ24UmYMLb-EGq4bvvHLOoIcMHJ'
        },

        commit: true, // Show a 'Pay Now' button

        payment: function (data, actions) {
            return actions.payment.create({
                payment: {
                    transactions: [
                        {
                            amount: { total: '13.00', currency: 'USD' }
                        }
                    ]
                }
            });
        },

        onAuthorize: function (data, actions) {
            return actions.payment.execute().then(function (payment) {

                // The payment is complete!
                // You can now show a confirmation message to the customer
            });
        }

    }, '#paypal-button');

</script>
    <asp:Button ID="btn_pago" runat="server" Text="" Visible="false" OnClick="btn_pago_Click" />
</asp:Content>
