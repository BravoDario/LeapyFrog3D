import { useEffect } from 'react';
import { Link } from 'react-router-dom';
import PropTypes from 'prop-types';
import ResumenInventario from '../../components/ResumenInventario/resumenInventario.jsx';

const Home = () => {

  useEffect(() => {
    console.log(`Home mounted`)
  }, [])

  return (
    <div className="Home-component p-8">
      <h1 className="text-3xl font-bold mb-6">Home</h1>
      <div className="grid grid-cols-3 grid-rows-2 gap-4">
        <div >Grafica de algo</div>
        <div className="col-span-2"><ResumenInventario /></div>
        <div className="row-start-2">
          <Link to="/compra" className="block p-4 bg-blue-500 text-white rounded hover:bg-blue-600 transition">
            Compra
          </Link>
        </div>
        <div className="row-start-2">
          <Link to="/inventario" className="block p-4 bg-green-500 text-white rounded hover:bg-green-600 transition">
            Inventario
          </Link>
        </div>
        <div className="row-start-2">
          <Link to="/sobras" className="block p-4 bg-purple-500 text-white rounded hover:bg-purple-600 transition">
            Sobras
          </Link>
        </div>
      </div>
    </div>
  )
}

Home.propTypes = {
  // bla: PropTypes.string,
};

Home.defaultProps = {
  // bla: 'test',
};

export default Home;
