import TextField from '@mui/material/TextField';
import * as React from 'react';
import IconButton from '@mui/material/IconButton';
import Visibility from '@mui/icons-material/Visibility';
import VisibilityOff from '@mui/icons-material/VisibilityOff';
import Button from '@mui/material/Button';
export default function Input(props: any) {
    const [showPassword, setShowPassword] = React.useState(false);

    const handleClickShowPassword = () => {
        setShowPassword((show) => !show);
        if (props.handleClickIcon) {
            props.handleClickIcon();
        }
    };

    const onChangeValue = (value: any) => {
        if (props.onChangeValue) {
            props.onChangeValue(value);
        }
    }

    const handleMouseDownPassword = (event: React.MouseEvent<HTMLButtonElement>) => {
        event.preventDefault();
    };
    return (
        <div>
            <TextField sx={{
                width: props.width ?? 300,

            }} onChange={(event: React.ChangeEvent<HTMLInputElement>) => {
                onChangeValue(event.target.value);
            }} size={props.size ?? 'small'} id={props.id ?? 'input'} type={props.type} value={props.value} disabled={props.disabled} placeholder={props.placeholder} required={props.required} helperText={props.helperText} InputProps={props.inputProps ? props.inputProps : props.isShowInput ? {
                endAdornment: <IconButton
                    aria-label="toggle password visibility"
                    onClick={handleClickShowPassword}
                    onMouseDown={handleMouseDownPassword}
                    edge="end"
                >
                    {showPassword ? <VisibilityOff /> : <Visibility />}
                </IconButton>
            } : null} />
        </div>
    );
}