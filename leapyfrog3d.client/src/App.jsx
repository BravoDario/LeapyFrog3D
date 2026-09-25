import { useEffect, useState } from 'react';
import './App.css';

function App() {
    const [filamentos, setFilamentos] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        populateFilamentos();
    }, []);

    async function populateFilamentos() {
        try {
            const response = await fetch('/api/Filamentos/inventarioFilamentos');
            if (!response.ok) {
                throw new Error(`HTTP ${response.status}`);
            }

            const data = await response.json();
            setFilamentos(data.filamentos ?? []);
        } catch (error) {
            console.error('No se pudo cargar el inventario:', error);
            setFilamentos([]);
        } finally {
            setLoading(false);
        }
    }

    return (
        <div className="app-shell">
            <h1 id="tableLabel">Inventario de filamentos</h1>
            <p>Materiales disponibles para impresión 3D.</p>

            {loading ? (
                <p><em>Cargando inventario...</em></p>
            ) : filamentos.length === 0 ? (
                <p><em>No hay filamentos disponibles.</em></p>
            ) : (
                <table className="filamentos-table" aria-labelledby="tableLabel">
                    <thead>
                        <tr>
                            <th>Código</th>
                            <th>Nombre</th>
                            <th>Color</th>
                            <th>Material</th>
                            <th>Marca</th>
                        </tr>
                    </thead>
                    <tbody>
                        {filamentos.map((filamento) => (
                            <tr key={filamento.idFilamento}>
                                <td>{filamento.codigo}</td>
                                <td>{filamento.nombre}</td>
                                <td>{filamento.color}</td>
                                <td>{filamento.material}</td>
                                <td>{filamento.marca}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            )}
        </div>
    );
}

export default App;