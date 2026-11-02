import { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import PropTypes from 'prop-types';
import { compraService } from '../../services/compraService';
import CompraFilamento from '../../components/compras/CompraFilamento';
import CompraAccesorio from '../../components/compras/CompraAccesorio';

const Compra = () => {
  const [tipoSeleccionado, setTipoSeleccionado] = useState('');
  const [filamentos, setFilamentos] = useState([]);
  const [accesorios, setAccesorios] = useState([]);
  const [editingFilamento, setEditingFilamento] = useState(null);
  const [editingAccesorio, setEditingAccesorio] = useState(null);
  const [loading, setLoading] = useState(false);

  const handleAgregarFilamento = () => {
    const nuevoFilamento = {
      id: Date.now(),
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
      id: Date.now(),
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

  const handleEditarFilamento = (index) => {
    const filamentoEditar = { ...filamentos[index], esEditando: true };
    setEditingFilamento(filamentoEditar);
    setFilamentos(prev => prev.map((f, i) => i === index ? filamentoEditar : f));
    setTipoSeleccionado('');
  };

  const handleEditarAccesorio = (index) => {
    const accesorioEditar = { ...accesorios[index], esEditando: true };
    setEditingAccesorio(accesorioEditar);
    setAccesorios(prev => prev.map((a, i) => i === index ? accesorioEditar : a));
    setTipoSeleccionado('');
  };

  const handleGuardarEdicionFilamento = (index, datosActualizados) => {
    const nuevosFilamentos = [...filamentos];
    nuevosFilamentos[index] = { ...datosActualizados, esEditando: false };
    setFilamentos(nuevosFilamentos);
    setEditingFilamento(null);
  };

  const handleGuardarEdicionAccesorio = (index, datosActualizados) => {
    const nuevosAccesorios = [...accesorios];
    nuevosAccesorios[index] = { ...datosActualizados, esEditando: false };
    setAccesorios(nuevosAccesorios);
    setEditingAccesorio(null);
  };

  const handleCancelarEdicion = () => {
    setEditingFilamento(null);
    setEditingAccesorio(null);
  };

  const handleGuardar = async () => {
    setLoading(true);
    try {
      const compra = {
        filamentosComprados: filamentos
          .filter(f => !f.esEditando)
          .map(f => ({
            idMarca: f.idMarca,
            idMaterial: f.idMaterial,
            color: f.color,
            costo: f.costo,
            peso: f.peso,
            idUnidad: f.idUnidad,
            piezas: f.piezas
          })),
        accesoriosComprados: accesorios
          .filter(a => !a.esEditando)
          .map(a => ({
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
      setEditingFilamento(null);
      setEditingAccesorio(null);
    } catch (error) {
      console.error('Error guardando compra:', error);
      alert('Error al guardar la compra');
    } finally {
      setLoading(false);
    }
  };

  const renderFilamentoItem = (filamento, index) => {
    if (filamento.esEditando && editingFilamento) {
      return (
        <CompraFilamento
          key={filamento.id || index}
          filamentoCompra={editingFilamento}
          onChange={(nuevosDatos) => handleGuardarEdicionFilamento(index, nuevosDatos)}
          onDelete={handleCancelarEdicion}
        />
      );
    }
    return (
      <div key={filamento.id || index} className="border p-4 rounded mb-4 bg-gray-50">
        <div className="flex justify-between items-start">
          <div>
            <h3 className="font-semibold">Filamento</h3>
            <p>Marca: {filamento.idMarca || 'Sin seleccionar'}</p>
            <p>Material: {filamento.idMaterial || 'Sin seleccionar'}</p>
            <p>Color: {filamento.color || 'Sin especificar'}</p>
            <p>Costo: ${filamento.costo || 0}</p>
            <p>Peso: {filamento.peso || 0}g</p>
            <p>Piezas: {filamento.piezas || 0}</p>
          </div>
          <div className="flex gap-2">
            <button
              onClick={() => handleEditarFilamento(index)}
              className="px-3 py-1 bg-blue-500 text-white rounded hover:bg-blue-600 transition"
            >
              Editar
            </button>
            <button
              onClick={() => handleEliminarFilamento(index)}
              className="px-3 py-1 bg-red-500 text-white rounded hover:bg-red-600 transition"
            >
              Eliminar
            </button>
          </div>
        </div>
      </div>
    );
  };

  const renderAccesorioItem = (accesorio, index) => {
    if (accesorio.esEditando && editingAccesorio) {
      return (
        <CompraAccesorio
          key={accesorio.id || index}
          accesorioCompra={editingAccesorio}
          onChange={(nuevosDatos) => handleGuardarEdicionAccesorio(index, nuevosDatos)}
          onDelete={handleCancelarEdicion}
        />
      );
    }
    return (
      <div key={accesorio.id || index} className="border p-4 rounded mb-4 bg-gray-50">
        <div className="flex justify-between items-start">
          <div>
            <h3 className="font-semibold">Accesorio</h3>
            <p>Nombre: {accesorio.nombre || 'Sin nombre'}</p>
            <p>Cantidad: {accesorio.cantidad || 0}</p>
            <p>Piezas: {accesorio.piezas || 0}</p>
          </div>
          <div className="flex gap-2">
            <button
              onClick={() => handleEditarAccesorio(index)}
              className="px-3 py-1 bg-blue-500 text-white rounded hover:bg-blue-600 transition"
            >
              Editar
            </button>
            <button
              onClick={() => handleEliminarAccesorio(index)}
              className="px-3 py-1 bg-red-500 text-white rounded hover:bg-red-600 transition"
            >
              Eliminar
            </button>
          </div>
        </div>
      </div>
    );
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
            {filamentos.map((filamento, index) => renderFilamentoItem(filamento, index))}
          </div>
        )}

        {/* Lista de accesorios */}
        {accesorios.length > 0 && (
          <div className="mb-6">
            <h2 className="text-xl font-semibold mb-3">Accesorios</h2>
            {accesorios.map((accesorio, index) => renderAccesorioItem(accesorio, index))}
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
