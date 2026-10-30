import { useEffect, useState } from "react";
import { compraService } from '../../services/compraService';

const CompraComponent = ({ agregarFilamento, filamentoCompra }) => {
    const [marcas, setMarcas] = useState([])
    const [materiales, setMateriales] = useState([])

    useEffect(() => {
        cargarDatos();
    })

    const cargarDatos = () => {
        try {
            setMarcas(compraService.obtenerMarcas);
            setMateriales(compraService.obtenerMateriales);
        }
        catch (error) {
            console.error('Error cargando datos:', error);
        }
    }

    const handleAgregarFilamento = () => {
        const filamento = {
            "mensaje": "agregado"
        }
        agregarFilamento(filamento)
    }

    return (
        <div>
            {
                marcas.length > 0 ?
                <select>{marcas.map(marca => 
                            <option key={marca.idMarca} value={marca.idMarca} selected={filamentoCompra.idMarca === marca.idMarca} >
                                {marca.nombre}
                            </option>
                        )}
                </select> :
                <p>Error al obtener las marcas</p>}
            {
                materiales.length > 0 ? 
                <select>
                    {
                        materiales.map(material => <option key={material.idMaterial} value={material.idMaterial} selected={filamentoCompra.idMaterial === material.idMaterial}>
                            {material.nombre}
                        </option>)
                    }
                </select> : 
                <p>Error al obtener los materiales</p>
            }
            <button onClick={handleAgregarFilamento()}>Agregar Filamento</button>
        </div>
    )
}

export default CompraComponent;