import WidgetsIcon from '@mui/icons-material/Widgets';
import InstagramIcon from '@mui/icons-material/Instagram';
import AddCircleOutlineIcon from '@mui/icons-material/AddCircleOutline';
import SettingsIcon from '@mui/icons-material/Settings';
import NotificationsIcon from '@mui/icons-material/Notifications';
import HelpOutlineIcon from '@mui/icons-material/HelpOutline';
import Avata from '../../../image/avata.jpg'
import Popover from '@mui/material/Popover';
import React, { useState, useEffect, useRef } from 'react';
import Typography from '@mui/material/Typography';

const InconNotiofyApp = () => {
    const [anchorNotifi, setAnchorEl] = React.useState<HTMLDivElement | null>();
    const handleClickNotifi = (event: React.MouseEvent<HTMLDivElement>) => {
        setAnchorEl(event.currentTarget);
    };

    const handleCloseNotifi = () => {
        setAnchorEl(null);
    };

    const openNotifi = Boolean(anchorNotifi);
    const idNotifi = openNotifi ? 'simple-popover' : undefined;

    const [listNotifi, setListNotifi] = React.useState([{
        AvataUser: Avata,
        AvataApp: Avata,
        Content: `Anh <strong>Phạm Vũ Minh Quân</strong> đã duyệt đề nghị cập nhật công của bạn`,
        Day: "Hôm qua",
    }, {
        AvataUser: Avata,
        AvataApp: Avata,
        Content: `Anh <strong>Phạm Vũ Minh Quân</strong> đã duyệt đề nghị cập nhật công của bạn`,
        Day: "Hôm qua",
    }, {
        AvataUser: Avata,
        AvataApp: Avata,
        Content: `Anh <strong>Phạm Vũ Minh Quân</strong> đã duyệt đề nghị cập nhật công của bạn`,
        Day: "Hôm qua",
    }, {
        AvataUser: Avata,
        AvataApp: Avata,
        Content: `Anh <strong>Phạm Vũ Minh Quân</strong> đã duyệt đề nghị cập nhật công của bạn`,
        Day: "Hôm qua",
    }, {
        AvataUser: Avata,
        AvataApp: Avata,
        Content: `Anh <strong>Phạm Vũ Minh Quân</strong> đã duyệt đề nghị cập nhật công của bạn`,
        Day: "Hôm qua",
    }, {
        AvataUser: Avata,
        AvataApp: Avata,
        Content: `Anh <strong>Phạm Vũ Minh Quân</strong> đã duyệt đề nghị cập nhật công của bạn`,
        Day: "Hôm qua",
    }, {
        AvataUser: Avata,
        AvataApp: Avata,
        Content: `Anh <strong>Phạm Vũ Minh Quân</strong> đã duyệt đề nghị cập nhật công của bạn`,
        Day: "Hôm qua",
    }, {
        AvataUser: Avata,
        AvataApp: Avata,
        Content: `Anh <strong>Phạm Vũ Minh Quân</strong> đã duyệt đề nghị cập nhật công của bạn`,
        Day: "Hôm qua",
    }, {
        AvataUser: Avata,
        AvataApp: Avata,
        Content: `Anh <strong>Phạm Vũ Minh Quân</strong> đã duyệt đề nghị cập nhật công của bạn`,
        Day: "Hôm qua",
    }, {
        AvataUser: Avata,
        AvataApp: Avata,
        Content: `Anh <strong>Phạm Vũ Minh Quân</strong> đã duyệt đề nghị cập nhật công của bạn`,
        Day: "Hôm qua",
    }, {
        AvataUser: Avata,
        AvataApp: Avata,
        Content: `Anh <strong>Phạm Vũ Minh Quân</strong> đã duyệt đề nghị cập nhật công của bạn`,
        Day: "Hôm qua",
    }, {
        AvataUser: Avata,
        AvataApp: Avata,
        Content: `Anh <strong>Phạm Vũ Minh Quân</strong> đã duyệt đề nghị cập nhật công của bạn`,
        Day: "Hôm qua",
    }, {
        AvataUser: Avata,
        AvataApp: Avata,
        Content: `Anh <strong>Phạm Vũ Minh Quân</strong> đã duyệt đề nghị cập nhật công của bạn`,
        Day: "Hôm qua",
    }, {
        AvataUser: Avata,
        AvataApp: Avata,
        Content: `Anh <strong>Phạm Vũ Minh Quân</strong> đã duyệt đề nghị cập nhật công của bạn`,
        Day: "Hôm qua",
    }, {
        AvataUser: Avata,
        AvataApp: Avata,
        Content: `Anh <strong>Phạm Vũ Minh Quân</strong> đã duyệt đề nghị cập nhật công của bạn`,
        Day: "Hôm qua",
    }, {
        AvataUser: Avata,
        AvataApp: Avata,
        Content: `Anh <strong>Phạm Vũ Minh Quân</strong> đã duyệt đề nghị cập nhật công của bạn`,
        Day: "Hôm qua",
    },]);

    const HtmlNotifile = (data: any) => {
        return (
            <div className='flex hover:bg-stone-100 rounded-lg p-2'>
                <div className='h-12 w-16 bg-white mx-2 rounded-full border-indigo-900 cursor-pointer flex items-center'>
                    <img src={data.AvataUser} alt="" className='rounded-full' />
                </div>
                <div className='cursor-pointer'>
                    <div className='text-sm' dangerouslySetInnerHTML={{ __html: data.Content }}>
                    </div>
                    <span className='text-xs text-gray-400'>{data.Day}</span>
                </div>
            </div>
        )
    }
    return (
        <div className='relative' id="notifi" aria-describedby={idNotifi} onClick={handleClickNotifi}>
            <NotificationsIcon className='text-white cursor-pointer mx-2 '></NotificationsIcon>
            <div className='absolute text-white size-5 bg-red-600 justify-center flex text-xs items-center -top-2 right-0 rounded-md'>
                20
            </div>
            <Popover
                id={idNotifi}
                open={openNotifi}
                anchorEl={anchorNotifi}
                onClose={handleCloseNotifi}
                anchorOrigin={{
                    vertical: 'bottom',
                    horizontal: 'center',
                }}
                transformOrigin={{
                    vertical: 'top',
                    horizontal: 'center',
                }}
            >
                <Typography><div className='w-96  p-4 '>
                    <div className='flex items-center mb-6'>
                        <span className='text-xl font-bold'>Thông báo</span>
                    </div>
                    <div className='max-h-128 min-h-96'>
                        {listNotifi.map((x) => HtmlNotifile(x))}
                    </div>
                </div>
                </Typography>
            </Popover>
        </div>
    )
}

// icon
const listIcon = [<AddCircleOutlineIcon className='text-white cursor-pointer mx-2'></AddCircleOutlineIcon>, <SettingsIcon className='text-white cursor-pointer mx-2' ></SettingsIcon>, <InconNotiofyApp></InconNotiofyApp>, <HelpOutlineIcon className='text-white cursor-pointer mx-2'></HelpOutlineIcon>]
const NavbarIcon = () => {
    return (
        listIcon
    )
}
// user
const User = () => {
    return (
        <div className='h-8 w-8 bg-white mx-2 rounded-full border-indigo-900 cursor-pointer'>
            <img src={Avata} alt="" className='rounded-full' />
        </div>
    )
}
const Navbar = () => {
    return (
        <div className="h-12 w-full bg-blue-800 flex px-6 justify-between">
            <div className="flex items-center">
                <WidgetsIcon className='text-white cursor-pointer'></WidgetsIcon>
                <InstagramIcon className='ml-4 text-pink-200'></InstagramIcon>
                <span className='flex ml-2 text-white cursor-pointer text-xl'>Mạng xã hội</span>
            </div>
            <div className='flex items-center'>
                <NavbarIcon></NavbarIcon>
                <User></User>
            </div>
        </div>
    )
}


export const Newsfeed = () => {
    return (<div>
        <Navbar></Navbar>
    </div>)
}