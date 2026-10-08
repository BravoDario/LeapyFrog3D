import { useEffect } from 'react';
import { Link } from 'react-router-dom';
import PropTypes from 'prop-types';

const Home = () => {

  useEffect(() => {
    console.log(`Home mounted`)
  }, [])

  return (
    <div className="Home-component p-8">
      <h1 className="text-3xl font-bold mb-6">Home</h1>
      <div className="grid gap-4 max-w-md">
        <Link to="/compra" className="block p-4 bg-blue-500 text-white rounded hover:bg-blue-600 transition">
          Compra
        </Link>
        <Link to="/inventario" className="block p-4 bg-green-500 text-white rounded hover:bg-green-600 transition">
          Inventario
        </Link>
        <Link to="/sobras" className="block p-4 bg-purple-500 text-white rounded hover:bg-purple-600 transition">
          Sobras
        </Link>
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
