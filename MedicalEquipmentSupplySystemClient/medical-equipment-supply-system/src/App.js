import {Route, Routes} from 'react-router-dom';

import AllSupplyCompaniesPage from './pages/SupplyCompanies';
import LoginPage from './pages/Login';
import RegistrationPage from './pages/Registration';
import Layout from './components/layout/Layout';
import ValidationPage from './pages/Validation';
import CompanyDetailsPage from './pages/CompanyDetails';
import MyProfilePage from './pages/MyProfile';
import ReservationsPage from './pages/Reservations';
import HistoryReservationsComponent from './components/reservations/userReservations/HistoryReservations';
import UpcomingReservationsComponent from './components/reservations/userReservations/UpcomingReservations';


function App() {
  return (
    <Layout>
      <Routes>
        <Route exact path='/' element = {<AllSupplyCompaniesPage/>}/>
        <Route path='/login' element = {<LoginPage/>}/>
        <Route path='/register' element = {<RegistrationPage/>}/>
        <Route path='/validate' element = {<ValidationPage/>}/>
        <Route path='/companyDetails/:id' element = {<CompanyDetailsPage/>}/>
        <Route path='/myprofile/:id' element = {<MyProfilePage/>}/>
        <Route path='/reservations/:id' element = {<ReservationsPage/>}/>
        <Route path='/reservations/history' element = {<HistoryReservationsComponent/>}/>
        <Route path='/reservations/upcoming' element = {<UpcomingReservationsComponent/>}/>
      </Routes>
    </Layout>
  );
}

export default App;
