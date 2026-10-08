import { useEffect } from 'react';
import PropTypes from 'prop-types';

const Inventario = () => {

  useEffect(() => {
    console.log(`Inventario mounted`)
  }, [])

  return (
    <div className="Inventario-component">
      Inventario
    </div>
  )
}

Inventario.propTypes = {
  // bla: PropTypes.string,
};

Inventario.defaultProps = {
  // bla: 'test',
};

export default Inventario;
