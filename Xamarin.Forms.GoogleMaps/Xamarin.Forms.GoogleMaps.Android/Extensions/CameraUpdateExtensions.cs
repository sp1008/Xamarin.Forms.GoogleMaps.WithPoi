﻿using System;
using GCameraUpdateFactory = Android.Gms.Maps.CameraUpdateFactory;
using GCameraUpdate = Android.Gms.Maps.CameraUpdate;
using Xamarin.Forms.GoogleMaps.Internals;

namespace Xamarin.Forms.GoogleMaps.Android.Extensions
{
    internal static class CameraUpdateExtensions
    {
        public static GCameraUpdate ToAndroid(this CameraUpdate self)
        {
            switch (self.UpdateType)
            {
                case CameraUpdateType.LatLng:
                    return GCameraUpdateFactory.NewLatLng(self.Position.ToLatLng());
                case CameraUpdateType.LatLngZoom:
                    return GCameraUpdateFactory.NewLatLngZoom(self.Position.ToLatLng(), (float) self.Zoom);
                case CameraUpdateType.LatLngBounds:
                    return GCameraUpdateFactory.NewLatLngBounds(self.Bounds.ToLatLngBounds(), self.Padding);
                case CameraUpdateType.CameraPosition:
                    return GCameraUpdateFactory.NewCameraPosition(self.CameraPosition.ToAndroid());
                default:
                    throw new ArgumentException($"{nameof(self)} UpdateType is not supported.");
            }
        }
    }
}
