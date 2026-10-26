import { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import PropTypes from 'prop-types';
import { compraService } from '../../services/compraService';

const Compra = () => {
  const [marcas, setMarcas] = useState([]);
  const [materiales, setMateriales] = useState([]);
  const [filamentos, setFilamentos] = useState([]);
  const [formData, setFormData] = useState({
    fecha: new Date().toISOString().split('T')[0],
    idFilamento: '',
    costo: '',
    peso: ''
  });
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    console.log(`Compra mounted`);
    cargarDatos();
  }, []);

  const cargarDatos = async () => {
    try {
      const [marcasRes, materialesRes,filamentosRes] = await Promise.all([
        compraService.obtenerMarcas(),
        compraService.obtenerMateriales(),
        compraService.obtenerFilamentos()
      ]);
      setMarcas(marcasRes || []);
      setMateriales(materialesRes || []);
      setFilamentos(filamentosRes || []);
    } catch (error) {
      console.error('Error cargando datos:', error);
    }
  };

  const handleFilamentoChange = (e) => {
    const { value } = e.target;
    setFormData(prev => ({ ...prev, idFilamento: value }));
  };

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setFormData(prev => ({ ...prev, [name]: value }));
  };

  const handleGuardar = async (e) => {
    e.preventDefault();
    setLoading(true);
    try {
      const compra = {
        detallesCompra: [{
          filamento: { idFilamento: parseInt(formData.idFilamento) },
          costo: parseFloat(formData.costo) || 0,
          peso: parseFloat(formData.peso) || 0
        }],
        fecha: formData.fecha,
        idCompra: 0
      };
      await compraService.guardarCompra(compra);
      alert('Compra guardada exitosamente');
      setFormData({
        fecha: new Date().toISOString().split('T')[0],
        idFilamento: '',
        costo: '',
        peso: ''
      });
    } catch (error) {
      console.error('Error guardando compra:', error);
      alert('Error al guardar la compra');
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="Compra-component p-8">
      <h1 className="text-3xl font-bold mb-6">Compra</h1>
      <div className="max-w-2xl">
        <Link to="/" className="inline-block mb-6 text-blue-600 hover:text-blue-800">
          ← Volver al Inicio
        </Link>
        <form onSubmit={handleGuardar} className="space-y-4">
          <div>
            <label className="block text-sm font-medium text-gray-700 mb-1">
              Fecha
            </label>
            <input
              type="date"
              name="fecha"
              value={formData.fecha}
              onChange={handleInputChange}
              required
              className="w-full p-2 border rounded"
            />
          </div>
          <div>
            <label className="block text-sm font-medium text-gray-700 mb-1">
              Filamento
            </label>
            <select
              name="idFilamento"
              value={formData.idFilamento}
              onChange={handleFilamentoChange}
              required
              className="w-full p-2 border rounded"
            >
              <option value="">Seleccionar filamento</option>
              {filamentos.map(f => (
                <option key={f.idFilamento} value={f.idFilamento}>
                  {f.codigo} - {f.nombre} ({f.color})
                </option>
              ))}
            </select>
          </div>
          <div>
            <label className="block text-sm font-medium text-gray-700 mb-1">
              Costo
            </label>
            <input
              type="number"
              name="costo"
              value={formData.costo}
              onChange={handleInputChange}
              step="0.01"
              required
              min="0"
              className="w-full p-2 border rounded"
            />
          </div>
          <div>
            <label className="block text-sm font-medium text-gray-700 mb-1">
              Peso (gramos)
            </label>
            <input
              type="number"
              name="peso"
              value={formData.peso}
              onChange={handleInputChange}
              step="1"
              required
              min="0"
              className="w-full p-2 border rounded"
            />
          </div>
          <button
            type="submit"
            disabled={loading}
            className="px-4 py-2 bg-green-500 text-white rounded hover:bg-green-600 transition disabled:bg-gray-400"
          >
            {loading ? 'Guardando...' : 'Guardar Compra'}
          </button>
        </form>
      </div>
    </div>
  );
}

Compra.propTypes = {
  // bla: PropTypes.string,
};

Compra.defaultProps = {
  // bla: 'test',
};

export default Compra;
