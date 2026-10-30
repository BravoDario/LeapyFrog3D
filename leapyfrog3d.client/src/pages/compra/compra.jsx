import { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import PropTypes from 'prop-types';
import { compraService } from '../../services/compraService';
import CompraFilamento from '../components/compras/CompraFilamento';
import CompraAccesorio from '../components/compras/CompraAccesorio';

const Compra = () => {
  const [tipoSeleccionado, setTipoSeleccionado] = useState('');
  const [filamentos, setFilamentos] = useState([]);
  const [accesorios, setAccesorios] = useState([]);
  const [loading, setLoading] = useState(false);

  const handleAgregarFilamento = () => {
    const nuevoFilamento = {
      idMarca: 0,
      idMaterial: 0,
      color: '',
      costo: 0,
      peso: 0,
      idUnidad: 0,
      piezas: 1
    };
    setFilamentos([...filamentos, nuevoFilamento]);
    setTipoSeleccionado('');
  };

  const handleAgregarAccesorio = () => {
    const nuevoAccesorio = {
      nombre: '',
      cantidad: 0,
      unidad: 0,
      piezas: 1
    };
    setAccesorios([...accesorios, nuevoAccesorio]);
    setTipoSeleccionado('');
  };

  const handleFilamentoChange = (index, nuevosDatos) => {
    const nuevosFilamentos = [...filamentos];
    nuevosFilamentos[index] = nuevosDatos;
    setFilamentos(nuevosFilamentos);
  };

  const handleAccesorioChange = (index, nuevosDatos) => {
    const nuevosAccesorios = [...accesorios];
    nuevosAccesorios[index] = nuevosDatos;
    setAccesorios(nuevosAccesorios);
  };

  const handleEliminarFilamento = (index) => {
    const nuevosFilamentos = filamentos.filter((_, i) => i !== index);
    setFilamentos(nuevosFilamentos);
  };

  const handleEliminarAccesorio = (index) => {
    const nuevosAccesorios = accesorios.filter((_, i) => i !== index);
    setAccesorios(nuevosAccesorios);
  };

  const handleGuardar = async () => {
    setLoading(true);
    try {
      const compra = {
        filamentosComprados: filamentos.map(f => ({
          idMarca: f.idMarca,
          idMaterial: f.idMaterial,
          color: f.color,
          costo: f.costo,
          peso: f.peso,
          idUnidad: f.idUnidad,
          piezas: f.piezas
        })),
        accesoriosComprados: accesorios.map(a => ({
          nombre: a.nombre,
          cantidad: a.cantidad,
          unidad: a.unidad,
          piezas: a.piezas
        }))
      };
      await compraService.guardarCompra(compra);
      alert('Compra guardada exitosamente');
      setFilamentos([]);
      setAccesorios([]);
      setTipoSeleccionado('');
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
        
        {/* Seleccionar tipo de elemento a agregar */}
        <div className="mb-6 p-4 border rounded bg-gray-50">
          <label className="block text-sm font-medium text-gray-700 mb-2">
            Agregar elemento:
          </label>
          <select
            value={tipoSeleccionado}
            onChange={(e) => setTipoSeleccionado(e.target.value)}
            className="w-full p-2 border rounded"
          >
            <option value="">Seleccionar tipo...</option>
            <option value="filamento">Filamento</option>
            <option value="accesorio">Accesorio</option>
          </select>
          
          {tipoSeleccionado === 'filamento' && (
            <button
              onClick={handleAgregarFilamento}
              className="mt-3 px-4 py-2 bg-blue-500 text-white rounded hover:bg-blue-600 transition"
            >
              Agregar Filamento
            </button>
          )}
          
          {tipoSeleccionado === 'accesorio' && (
            <button
              onClick={handleAgregarAccesorio}
              className="mt-3 px-4 py-2 bg-green-500 text-white rounded hover:bg-green-600 transition"
            >
              Agregar Accesorio
            </button>
          )}
        </div>

        {/* Lista de filamentos */}
        {filamentos.length > 0 && (
          <div className="mb-6">
            <h2 className="text-xl font-semibold mb-3">Filamentos</h2>
            {filamentos.map((filamento, index) => (
              <CompraFilamento
                key={index}
                filamentoCompra={filamento}
                onChange={(nuevosDatos) => handleFilamentoChange(index, nuevosDatos)}
                onDelete={() => handleEliminarFilamento(index)}
              />
            ))}
          </div>
        )}

        {/* Lista de accesorios */}
        {accesorios.length > 0 && (
          <div className="mb-6">
            <h2 className="text-xl font-semibold mb-3">Accesorios</h2>
            {accesorios.map((accesorio, index) => (
              <CompraAccesorio
                key={index}
                accesorioCompra={accesorio}
                onChange={(nuevosDatos) => handleAccesorioChange(index, nuevosDatos)}
                onDelete={() => handleEliminarAccesorio(index)}
              />
            ))}
          </div>
        )}

        {/* Botón guardar */}
        <button
          onClick={handleGuardar}
          disabled={loading || (filamentos.length === 0 && accesorios.length === 0)}
          className="w-full py-3 bg-green-500 text-white rounded hover:bg-green-600 transition disabled:bg-gray-400"
        >
          {loading ? 'Guardando...' : 'Guardar Compra'}
        </button>
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
