

function displayButtons(element) {
    var style = {
        layout: 'vertical',
        shape: 'rect',
        label: 'paypal'
    }

    var createOrder = {

    }

    paypal.Buttons({ style }).render(element);
}