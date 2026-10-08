import { Routes, Route } from "react-router-dom";
import Home from "./pages/Home/home";
import Compra from "./pages/compra";
import Inventario from "./pages/inventario";
import Sobras from "./pages/sobras";

const App = () => {
    return (
        <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/compra" element={<Compra />} />
            <Route path="/inventario" element={<Inventario />} />
            <Route path="/sobras" element={<Sobras />} />
        </Routes>
    );
};

export default App;
