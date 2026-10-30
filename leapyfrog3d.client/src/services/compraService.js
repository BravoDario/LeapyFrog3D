import axios from 'axios';

const api = axios.create({
  baseURL: 'http://localhost:5183/api',
});

export const compraService = {
  guardarCompra: async (compra) => (await api.post('/compras/guardarCompra', compra)).data,
  obtenerMarcas: async () => (await api.get('/marcas')).data,
  obtenerMateriales: async () => (await api.get('/materiales')).data,
  obtenerFilamentos: async () => {
    const response = await api.get('/filamentos');
    return response.data?.[0]?.filamentos || [];
  },
  obtenerUnidades: async () => {
    try {
      const response = await api.get('/unidades');
      return response.data || [];
    } catch (error) {
      console.error('Error obteniendo unidades:', error);
      return [];
    }
  },
};
