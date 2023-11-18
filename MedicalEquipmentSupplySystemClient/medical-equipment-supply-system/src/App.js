import {Route, Routes} from 'react-router-dom';

import AllSupplyCompaniesPage from './pages/SupplyCompanies';
import LoginPage from './pages/Login';
import RegistrationPage from './pages/Registration';
import MainNavigation from './components/layout/MainNavigation';

function App() {
  return (
    <div>
      <MainNavigation/>
      <Routes>
        <Route exact path='/' element = {<AllSupplyCompaniesPage/>}/>
        <Route path='/login' element = {<LoginPage/>}/>
        <Route path='/register' element = {<RegistrationPage/>}/>
      </Routes>
    </div>
  );
}

export default App;
