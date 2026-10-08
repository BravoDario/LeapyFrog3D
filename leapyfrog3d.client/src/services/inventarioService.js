import axios from 'axios';

const api = axios.create({
  baseURL: 'http://localhost:5000/api/inventario',
});

export const inventarioService = {
  getInventario: async () => (await api.get('/inventario')).data,
  getFilamentos: async () => (await api.get('/filamentos/%{id}')).data,
  guardarCompra: async (compra) => (await api.post('/compras', compra)).data,
};