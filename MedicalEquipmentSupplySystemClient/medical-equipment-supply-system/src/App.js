import {Route, Routes} from 'react-router-dom';

import AllSupplyCompaniesPage from './pages/SupplyCompanies';
import LoginPage from './pages/Login';
import RegistrationPage from './pages/Registration';
import Layout from './components/layout/Layout';
import ValidationPage from './pages/Validation';
import CompanyDetailsPage from './pages/CompanyDetails';

function App() {
  return (
    <Layout>
      <Routes>
        <Route exact path='/' element = {<AllSupplyCompaniesPage/>}/>
        <Route path='/login' element = {<LoginPage/>}/>
        <Route path='/register' element = {<RegistrationPage/>}/>
        <Route path='/validate' element = {<ValidationPage/>}/>
        <Route path='/companyDetails/:id' element = {<CompanyDetailsPage/>}/>
      </Routes>
    </Layout>
  );
}

export default App;