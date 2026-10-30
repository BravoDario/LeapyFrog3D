import { useEffect, useState } from 'react';
import { compraService } from '../../services/compraService';

const CompraFilamento = ({ filamentoCompra, onChange, onDelete }) => {
  const [marcas, setMarcas] = useState([]);
  const [materiales, setMateriales] = useState([]);
  const [unidades, setUnidades] = useState([]);

  useEffect(() => {
    cargarDatos();
  }, []);

  const cargarDatos = async () => {
    try {
      const [marcasRes, materialesRes, unidadesRes] = await Promise.all([
        compraService.obtenerMarcas(),
        compraService.obtenerMateriales(),
        compraService.obtenerUnidades()
      ]);
      setMarcas(marcasRes || []);
      setMateriales(materialesRes || []);
      setUnidades(unidadesRes || []);
    } catch (error) {
      console.error('Error cargando datos:', error);
    }
  };

  const handleChange = (field, value) => {
    onChange({ ...filamentoCompra, [field]: value });
  };

  return (
    <div className="border p-4 rounded mb-4 bg-gray-50">
      <h3 className="font-semibold mb-3">Filamento</h3>
      <div className="grid grid-cols-2 gap-3">
        <div>
          <label className="block text-sm font-medium text-gray-700 mb-1">Marca</label>
          <select
            value={filamentoCompra.idMarca || ''}
            onChange={(e) => handleChange('idMarca', parseInt(e.target.value))}
            className="w-full p-2 border rounded"
          >
            <option value="">Seleccionar</option>
            {marcas.map(marca => (
              <option key={marca.idMarca} value={marca.idMarca}>
                {marca.nombre}
              </option>
            ))}
          </select>
        </div>
        <div>
          <label className="block text-sm font-medium text-gray-700 mb-1">Material</label>
          <select
            value={filamentoCompra.idMaterial || ''}
            onChange={(e) => handleChange('idMaterial', parseInt(e.target.value))}
            className="w-full p-2 border rounded"
          >
            <option value="">Seleccionar</option>
            {materiales.map(material => (
              <option key={material.idMaterial} value={material.idMaterial}>
                {material.nombre}
              </option>
            ))}
          </select>
        </div>
        <div>
          <label className="block text-sm font-medium text-gray-700 mb-1">Color</label>
          <input
            type="text"
            value={filamentoCompra.color || ''}
            onChange={(e) => handleChange('color', e.target.value)}
            placeholder="Ej: Azul"
            className="w-full p-2 border rounded"
          />
        </div>
        <div>
          <label className="block text-sm font-medium text-gray-700 mb-1">Costo</label>
          <input
            type="number"
            value={filamentoCompra.costo || ''}
            onChange={(e) => handleChange('costo', parseFloat(e.target.value))}
            step="0.01"
            min="0"
            className="w-full p-2 border rounded"
          />
        </div>
        <div>
          <label className="block text-sm font-medium text-gray-700 mb-1">Peso (gr)</label>
          <input
            type="number"
            value={filamentoCompra.peso || ''}
            onChange={(e) => handleChange('peso', parseFloat(e.target.value))}
            step="1"
            min="0"
            className="w-full p-2 border rounded"
          />
        </div>
        <div>
          <label className="block text-sm font-medium text-gray-700 mb-1">Unidad</label>
          <select
            value={filamentoCompra.idUnidad || ''}
            onChange={(e) => handleChange('idUnidad', parseInt(e.target.value))}
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
            value={filamentoCompra.piezas || ''}
            onChange={(e) => handleChange('piezas', parseInt(e.target.value))}
            min="1"
            className="w-full p-2 border rounded"
          />
        </div>
        <div className="flex items-end">
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

export default CompraFilamento;
