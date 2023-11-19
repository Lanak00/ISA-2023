import classes from './SupplyCompanyItem.module.css'
import HoverCard from '../ui/HoverCard';
import { Link } from 'react-router-dom';

function SupplyCompanyItem(props) {
    return (
        <li className={classes.item}>
            <button>
                <HoverCard>
                <Link to= {{
                    pathname:`/companyDetails/${props.id}`,
                }}>
                    <div className={classes.allcont}>
                        <div className={classes.image}>
                            <img src={props.image} alt={props.name}/>
                        </div>
                        <div className={classes.content}>
                            <h3>{props.name}</h3>
                            <address>{props.address + " " + props.city}</address>
                            <p>{props.description}</p>
                        </div>
                    </div>
                    </Link>
                </HoverCard>
            </button>
        </li>
    );
}

export default SupplyCompanyItem;