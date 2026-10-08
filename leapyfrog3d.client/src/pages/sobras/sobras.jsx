import { useEffect } from 'react';
import PropTypes from 'prop-types';

const Sobras = () => {

  useEffect(() => {
    console.log(`Sobras mounted`)
  }, [])

  return (
    <div className="Sobras-component">
      Sobras
    </div>
  )
}

Sobras.propTypes = {
  // bla: PropTypes.string,
};

Sobras.defaultProps = {
  // bla: 'test',
};

export default Sobras;
