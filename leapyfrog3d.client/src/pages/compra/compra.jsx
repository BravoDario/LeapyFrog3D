import { useEffect } from 'react';
import PropTypes from 'prop-types';

const Compra = () => {

  useEffect(() => {
    console.log(`Compra mounted`)
  }, [])

  return (
    <div className="Compra-component">
      Compra
    </div>
  )
}

Compra.propTypes = {
  // bla: PropTypes.string,
};

Compra.defaultProps = {
  // bla: 'test',
};

export default Compra;
