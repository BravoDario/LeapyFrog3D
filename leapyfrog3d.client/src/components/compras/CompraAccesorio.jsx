import { useEffect, useState } from 'react';
import { compraService } from '../../services/compraService';

const CompraAccesorio = ({ accesorioCompra, onChange, onDelete }) => {
  const [unidades, setUnidades] = useState([]);

  useEffect(() => {
    cargarDatos();
  }, []);

  const cargarDatos = async () => {
    try {
      const unidadesRes = await compraService.obtenerUnidades();
      setUnidades(unidadesRes || []);
    } catch (error) {
      console.error('Error cargando datos:', error);
    }
  };

  const handleChange = (field, value) => {
    onChange({ ...accesorioCompra, [field]: value });
  };

  return (
    <div className="border p-4 rounded mb-4 bg-gray-50">
      <h3 className="font-semibold mb-3">Accesorio</h3>
      <div className="grid grid-cols-2 gap-3">
        <div>
          <label className="block text-sm font-medium text-gray-700 mb-1">Nombre</label>
          <input
            type="text"
            value={accesorioCompra.nombre || ''}
            onChange={(e) => handleChange('nombre', e.target.value)}
            placeholder="Ej: Soporte filamentador"
            className="w-full p-2 border rounded"
          />
        </div>
        <div>
          <label className="block text-sm font-medium text-gray-700 mb-1">Cantidad</label>
          <input
            type="number"
            value={accesorioCompra.cantidad || ''}
            onChange={(e) => handleChange('cantidad', parseFloat(e.target.value))}
            step="1"
            min="0"
            className="w-full p-2 border rounded"
          />
        </div>
        <div>
          <label className="block text-sm font-medium text-gray-700 mb-1">Unidad</label>
          <select
            value={accesorioCompra.unidad || ''}
            onChange={(e) => handleChange('unidad', parseInt(e.target.value))}
            className="w-full p-2 border rounded"
          >
            <option value="">Seleccionar</option>
            {unidades.map(unidad => (
              <option key={unidad.idUnidad} value={unidad.idUnidad}>
                {unidad.nombre}
              </option>
            ))}
          </select>
        </div>
        <div>
          <label className="block text-sm font-medium text-gray-700 mb-1">Piezas</label>
          <input
            type="number"
            value={accesorioCompra.piezas || ''}
            onChange={(e) => handleChange('piezas', parseInt(e.target.value))}
            min="1"
            className="w-full p-2 border rounded"
          />
        </div>
        <div className="col-span-2 flex items-end">
          <button
            onClick={onDelete}
            className="w-full py-2 bg-red-500 text-white rounded hover:bg-red-600 transition"
          >
            Eliminar
          </button>
        </div>
      </div>
    </div>
  );
};

export default CompraAccesorio;
