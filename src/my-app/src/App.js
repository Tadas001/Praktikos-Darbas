import "./App.css";
import Employeelist from "./components/get";
import Insert from "./components/insert";

function Appp() {
    return (
      <div className="app-container">
        <Employeelist/>
        <Insert/>
      </div>
    );
  }

export default Appp;