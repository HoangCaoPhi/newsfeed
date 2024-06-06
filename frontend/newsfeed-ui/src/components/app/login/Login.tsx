import Input from "../../base/input/input"
import "./login.scss"
import React, { useState } from 'react';
import Button from '@mui/material/Button';
import FacebookIcon from '@mui/icons-material/Facebook';
import GoogleIcon from '@mui/icons-material/Google';
export default function MyApp() {
    const [showPassword, setShowPassword] = useState(false);
    const handleClickShowPassword = () => {
        setShowPassword((show) => !show);
        setDataLogin(dataLogin.map((x, index) => ({ ...x, Type: index == 1 ? !showPassword ? 'text' : 'password' : x.Type })))
    };

    const onChangeValueInput = (value: any, data: any) => {
        setDataLogin((dataLogin) => dataLogin.map((x, index) => ({ ...x, Value: x.Key == data?.Key ? value : x.Value })))
    }

    const login = () => {
        // var paramSave = useState<object>({});
        // var keySave = ["UserName", "PassWord"];
        // keySave.forEach((key, x) => {
        //     paramSave[`${key}`] = dataLogin.find((x) => x.IDInput == key)?.Value;
        // })
        // console.log(paramSave)
    }


    const [dataLogin, setDataLogin] = useState([{
        Description: "Tài khoản",
        IsRequired: true,
        Type: 'text',
        Value: "",
        Key: 1,
        IDInput: 'UserName'

    }, {
        Description: "Mật khẩu",
        IsRequired: true,
        Type: 'password',
        Value: "",
        Key: 2,
        IDInput: 'PassWord',
        IsShowInput: true,
    }]);


    function InputResign(data: any) {
        return (
            <div className="item" key={data.Key}>
                <div className="item-name">
                    <span className="f-13">{data.Description}</span>{data.IsRequired && <span className="icon-required">*</span>}
                </div>
                <Input onChangeValue={(event: React.ChangeEvent<HTMLInputElement>) => {
                    onChangeValueInput(event, data);
                }} handleClickIcon={handleClickShowPassword} id={data.IDInput} width="100%" type={data.Type} required={data.IsRequired} inputProps={data.InputProps} isShowInput={data.IsShowInput}></Input>
            </div>
        );
    }

    return (
        <div className="login flex content-center">

            <div className="login-ground">
                <div className="login-item items-center"><div><h2>Đăng nhập</h2></div><div>{dataLogin.map((x) => InputResign(x))}</div> <Button sx={{
                    width: '100%',
                    marginTop: '8px',
                    backgroundColor: '#ee4d2d',
                    ":hover": {
                        backgroundColor: "#f05d40"
                    },

                }} variant="contained" size="medium" onClick={login}>
                    Đăng nhập
                </Button><div className='flex content-between link'>
                        <a className="link-item" href="">Quên mật khẩu</a>
                        <a className="link-item" href="">Đăng nhập với SMS</a></div>
                    <div className="flex items-center">
                        <div className="line" ></div>
                        <span className="text-line">HOẶC</span>
                        <div className="line"></div>
                    </div>
                    <div className="flex content-between" style={{ marginTop: '16px' }}>
                        <Button
                            component="label"
                            role={undefined}
                            variant="contained"
                            tabIndex={-1}
                            sx={{
                                width: '100%',
                                marginRight: "8px",
                                backgroundColor: "#fff",
                                color: "rgba(0,0,0,.87)",
                                ":hover": {
                                    backgroundColor: 'rgba(0,0,0,.02)',
                                }
                            }}

                            startIcon={<FacebookIcon sx={{ color: 'blue' }} />}
                        >
                            Facebook
                        </Button>
                        <Button
                            component="label"
                            role={undefined}
                            variant="contained"
                            tabIndex={-1}
                            sx={{
                                width: '100%',
                                marginLeft: '8px',
                                backgroundColor: "#fff",
                                color: "rgba(0,0,0,.87)",
                                ":hover": {
                                    backgroundColor: 'rgba(0,0,0,.02)',
                                }
                            }}
                            startIcon={<GoogleIcon sx={{ color: 'red' }} />}
                        >
                            Google
                        </Button>
                    </div>
                    <div className="flex content-center " >
                        <span className="resgin">Đăng ký </span>
                    </div>
                </div>

            </div>
        </div>
    );


}