﻿using System.Collections.Generic;
using Orchard.Environment.Extensions;
using Orchard.Localization;
using Orchard.UI.Admin.Notification;
using Orchard.UI.Notify;

namespace NGM.OpenAuthentication.Core.OAuth.LiveId.Services {
    [OrchardFeature("MicrosoftConnect")]
    public class LiveIdServiceNotificationProvider: INotificationProvider {
        private readonly IOAuthProviderAuthenticator _oAuthProviderAuthenticator;

        public LiveIdServiceNotificationProvider(IOAuthProviderAuthenticator oAuthProviderAuthenticator) {
            _oAuthProviderAuthenticator = oAuthProviderAuthenticator;
            T = NullLocalizer.Instance;
        }

        public Localizer T { get; set; }

        public IEnumerable<NotifyEntry> GetNotifications() {
            if (!_oAuthProviderAuthenticator.IsConsumerConfigured) {
                yield return new NotifyEntry { Message = T("You need to add ClientKeyIdentifier and ClientSecret to enable MicrosoftConnect feature."), Type = NotifyType.Warning };
            }
        }
    }
}
