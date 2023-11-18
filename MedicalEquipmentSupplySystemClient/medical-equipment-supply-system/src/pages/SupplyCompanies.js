import SupplyCompanyList from "../components/companies/SupplyCompanyList";

const DUMMY_DATA = [
    {
        id : 1,
        name: 'Supply Company 1',
        address: 'Bulevar Oslobodjenja 2',
        city: 'Backa Palanka',
        rating: 4.3,
        image: 'https://upload.wikimedia.org/wikipedia/commons/3/3d/Hartford_Hospital_main_entrance.JPG',
        description: 'Pharmaceutical Information Centre has changed its name to Pharmaca Health Intelligence Ltd and renews its brand to better serve its customers in Finland and internationally. The new name and brand support the company’s internationalization goals and clarify its service offering'
        
    },
  
    {
        id : 2,
        name: 'Supply Company 2',
        address: 'Blagoja Parovica 81',
        city: 'Backa Palanka',
        rating: 4.3,
        image: 'https://upload.wikimedia.org/wikipedia/commons/a/a2/Biandintz_eta_zaldiak_-_modified2.jpg',
        description: 'Pharmaceutical Information Centre has changed its name to Pharmaca Health Intelligence Ltd and renews its brand to better serve its customers in Finland and internationally. The new name and brand support the company’s internationalization goals and clarify its service offering. '
    },
    {
        id : 3,
        name: 'Supply Company 3',
        address: 'Kosovska 18',
        city: 'Leskovac',
        rating: 4.9,
        image: 'https://upload.wikimedia.org/wikipedia/commons/3/30/Jubilee_and_Munin%2C_Ravens%2C_Tower_of_London_2016-04-30.jpg',
        description: 'Pharmaceutical Information Centre has traveled a great and growth-oriented journey. Pharmaca Health Intelligence Ltd, more familiarly Pharmaca, is a tribute to nearly 50 years of development work. Not to forget Pharmaca Fennica®’s pharmaceutical information, which will continue to be the heart of the business also in the future '
    }
]

function AllSupplyCompaniesPage() {

    return (
        <section>
          <SupplyCompanyList companies = {DUMMY_DATA}/>
        </section>
    );
}

export default AllSupplyCompaniesPage;