import { Link } from 'react-router-dom';
import ResumenInventario from '../../components/ResumenInventario/resumenInventario.jsx';

const Home = () => {

  return (
    <main className="Home-component mx-auto w-full max-w-7xl p-6 sm:p-8">
      <header className="mb-8">
        <p className="text-sm font-semibold uppercase tracking-wider text-indigo-600">Panel principal</p>
        <h1 className="mt-2 text-3xl font-bold tracking-tight text-slate-900 sm:text-4xl">Resumen</h1>
        <p className="mt-2 text-slate-500">Consulta el inventario y accede a las operaciones.</p>
      </header>

      <div className="grid grid-cols-1 gap-6 lg:grid-cols-3">
        <section className="rounded-xl border border-slate-200 bg-white p-6 shadow-sm lg:col-span-1">
          <h2 className="text-lg font-semibold text-slate-900">Actividad</h2>
          <div className="mt-5 flex h-48 items-center justify-center rounded-lg border border-dashed border-slate-300 bg-slate-50 text-sm text-slate-500">
            Grafica de algo
          </div>
        </section>

        <div className="lg:col-span-2">
          <ResumenInventario />
        </div>
      </div>

      <nav aria-label="Accesos principales" className="mt-8 grid grid-cols-1 gap-4 sm:grid-cols-3">
        <Link
          to="/compra"
          className="rounded-xl bg-blue-600 p-5 font-semibold text-white shadow-sm transition hover:bg-blue-700 focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-blue-600"
        >
          Compra
          <span className="mt-1 block text-sm font-normal text-blue-100">Registrar una compra</span>
        </Link>
        <Link
          to="/inventario"
          className="rounded-xl bg-green-600 p-5 font-semibold text-white shadow-sm transition hover:bg-green-700 focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-green-600"
        >
          Inventario
          <span className="mt-1 block text-sm font-normal text-green-100">Consultar materiales</span>
        </Link>
        <Link
          to="/sobras"
          className="rounded-xl bg-purple-600 p-5 font-semibold text-white shadow-sm transition hover:bg-purple-700 focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-purple-600"
        >
          Sobras
          <span className="mt-1 block text-sm font-normal text-purple-100">Revisar sobrantes</span>
        </Link>
      </nav>
    </main>
  )
}

Home.propTypes = {
  // bla: PropTypes.string,
};

Home.defaultProps = {
  // bla: 'test',
};

export default Home;
