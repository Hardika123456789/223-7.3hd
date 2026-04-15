async function getMenu() {
  const res = await fetch('/api/menu');
  const data = await res.json();
  document.getElementById('menu').innerHTML = data.map(x => `<li>${x.name}</li>`).join('');
}

async function placeOrder() {
  const item = document.getElementById('orderInput').value;
  await fetch('/api/order', {
    method: 'POST',
    headers: {'Content-Type':'application/json'},
    body: JSON.stringify(item)
  });
  alert('Order placed');
}

async function getOrders() {
  const res = await fetch('/api/order');
  const data = await res.json();
  document.getElementById('orders').innerHTML = data.map(x => `<li>${x}</li>`).join('');
}
